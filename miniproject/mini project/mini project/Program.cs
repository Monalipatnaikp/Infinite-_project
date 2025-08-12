using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RailwayReservationSystem
{

    public class DbHelper
    {
        private readonly string connectionString = "Server=ICS-LT-7Z33D64\\SQLEXPRESS01;Database=railwaydb;user id=sa;password=Monalipatnaik@123;";

        public void ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                foreach (var param in parameters)
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameters != null)
                    foreach (var param in parameters)
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }


    public class CustomerService
    {
        private readonly DbHelper db = new DbHelper();
        public void RegisterCustomer(int custId, string name, string phone, string mail)
        {
            string query = @"INSERT INTO customerss (custid, custname, phone, mailid) VALUES (@id, @name, @phone, @mail)";
            db.ExecuteNonQuery(query, new Dictionary<string, object>
            {
                {"@id", custId},
                {"@name", name},
                {"@phone", phone},
                {"@mail", mail}
            });
            Console.WriteLine("Customer registered successfully.");
        }
    }


    public class ReservationService
    {
        private readonly DbHelper db = new DbHelper();
        public void BookTicket(int bookingId, int custId, string custName, DateTime travelDate, string classType, int seats)
        {
            string trainQuery = @"SELECT costperseat FROM trains WHERE class = @class";
            var trainData = db.ExecuteQuery(trainQuery, new Dictionary<string, object> { { "@class", classType } });

            if (trainData.Rows.Count == 0)
            {
                Console.WriteLine("Train class not found.");
                return;
            }

            decimal costPerSeat = (decimal)trainData.Rows[0]["costperseat"];
            decimal totalCost = costPerSeat * seats;
            DateTime bookingDate = DateTime.Now;

            string insertQuery = @"INSERT INTO reservation (bookingid, custno, custname, traveldate, class, seatsbooked, totalcost, bookingdate)
                                   VALUES (@bid, @cid, @name, @tdate, @class, @seats, @cost, @bdate)";
            db.ExecuteNonQuery(insertQuery, new Dictionary<string, object>
            {
                {"@bid", bookingId},
                {"@cid", custId},
                {"@name", custName},
                {"@tdate", travelDate},
                {"@class", classType},
                {"@seats", seats},
                {"@cost", totalCost},
                {"@bdate", bookingDate}
            });

            Console.WriteLine("Reservation successful.");
        }

        public void PrintTicket(int bookingId)
        {
            string query = @"SELECT * FROM reservation WHERE bookingid = @bid";
            var data = db.ExecuteQuery(query, new Dictionary<string, object> { { "@bid", bookingId } });

            if (data.Rows.Count == 0)
            {
                Console.WriteLine("Ticket not found.");
                return;
            }

            var row = data.Rows[0];
            Console.WriteLine("\nTicket Details:");
            Console.WriteLine($"Booking ID: {row["bookingid"]}");
            Console.WriteLine($"Customer Name: {row["custname"]}");
            Console.WriteLine($"Travel Date: {Convert.ToDateTime(row["traveldate"]).ToShortDateString()}");
            Console.WriteLine($"Class: {row["class"]}");
            Console.WriteLine($"Seats Booked: {row["seatsbooked"]}");
            Console.WriteLine($"Total Cost: ₹{row["totalcost"]}");
            Console.WriteLine($"Booking Date: {Convert.ToDateTime(row["bookingdate"]).ToShortDateString()}");
        }
    }


    public class CancellationService
    {
        private readonly DbHelper db = new DbHelper();
        public void CancelTicket(int bookingId)
        {
            string query = @"SELECT totalcost FROM reservation WHERE bookingid = @bid";
            var data = db.ExecuteQuery(query, new Dictionary<string, object> { { "@bid", bookingId } });

            if (data.Rows.Count == 0)
            {
                Console.WriteLine("Booking not found.");
                return;
            }

            decimal totalCost = (decimal)data.Rows[0]["totalcost"];
            decimal refund = totalCost * 0.5m;
            DateTime cancelDate = DateTime.Now;

            string insertCancel = @"INSERT INTO cancellation (bid, ticketcancelled, refundamount, cancellationdate)
                                    VALUES (@bid, 1, @refund, @date)";
            db.ExecuteNonQuery(insertCancel, new Dictionary<string, object>
            {
                {"@bid", bookingId},
                {"@refund", refund},
                {"@date", cancelDate}
            });

            string deleteReservation = "DELETE FROM reservation WHERE bookingid = @bid";
            db.ExecuteNonQuery(deleteReservation, new Dictionary<string, object> { { "@bid", bookingId } });

            Console.WriteLine($"Ticket cancelled. Refund: ₹{refund}");
        }
    }

    public class TrainService
    {
        private readonly DbHelper db = new DbHelper();

        public void AddTrain(int trainNo, string trainName, string classType, decimal costPerSeat)
        {
            string query = @"INSERT INTO trains (trainno, trainname, class, costperseat)
                             VALUES (@no, @name, @class, @cost)";
            db.ExecuteNonQuery(query, new Dictionary<string, object>
            {
                {"@no", trainNo},
                {"@name", trainName},
                {"@class", classType},
                {"@cost", costPerSeat}
            });
            Console.WriteLine("Train added successfully.");
        }

        public void DeleteTrain(int trainNo)
        {
            string query = "DELETE FROM trains WHERE trainno = @no";
            db.ExecuteNonQuery(query, new Dictionary<string, object> { { "@no", trainNo } });
            Console.WriteLine("Train deleted successfully.");
        }

        public void ViewAllTrains()
        {
            DataTable trains = db.ExecuteQuery("SELECT * FROM trains");
            Console.WriteLine("\nAll Trains:");
            foreach (DataRow row in trains.Rows)
            {
                Console.WriteLine($"No: {row["trainno"]}, Name: {row["trainname"]}, Class: {row["class"]}, Cost: ₹{row["costperseat"]}");
            }
        }
    }


    public class TrainClassService
    {
        private readonly DbHelper db = new DbHelper();

        public void AddTrainClass(string className, decimal costPerSeat)
        {
            string query = @"INSERT INTO trainclasses (classname, costperseat)
                             VALUES (@class, @cost)";
            db.ExecuteNonQuery(query, new Dictionary<string, object>
            {
                {"@class", className},
                {"@cost", costPerSeat}
            });
            Console.WriteLine("Train class added successfully.");
        }

        public void ViewTrainClasses()
        {
            DataTable classes = db.ExecuteQuery("SELECT * FROM trainclasses");
            Console.WriteLine("\nTrain Classes:");
            foreach (DataRow row in classes.Rows)
            {
                Console.WriteLine($"Class: {row["classname"]}, Cost: ₹{row["costperseat"]}");
            }
        }
    }


    public class BookingReportService
    {
        private readonly DbHelper db = new DbHelper();

        public void ViewAllBookings()
        {
            DataTable bookingData = db.ExecuteQuery("SELECT * FROM reservation");
            Console.WriteLine("\nAll Bookings:");
            foreach (DataRow row in bookingData.Rows)
            {
                Console.WriteLine($"Booking ID: {row["bookingid"]}, Customer: {row["custname"]}, Date: {row["traveldate"]}, Class: {row["class"]}, Seats: {row["seatsbooked"]}, Cost: ₹{row["totalcost"]}");
            }
        }

        public void ViewAllCancellations()
        {
            DataTable cancelData = db.ExecuteQuery("SELECT * FROM cancellation");
            Console.WriteLine("\nAll Cancellations:");
            foreach (DataRow row in cancelData.Rows)
            {
                Console.WriteLine($"Booking ID: {row["bid"]}, Refund: ₹{row["refundamount"]}, Date: {row["cancellationdate"]}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var custService = new CustomerService();
            var resService = new ReservationService();
            var cancelService = new CancellationService();
            var trainService = new TrainService();
            var trainClassService = new TrainClassService();
            var bookingReport = new BookingReportService();

            Console.Write(" (admin/user): ");
            string role = Console.ReadLine().ToLower();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if ((role == "admin" && password != "admin123") || (role == "user" && password != "user123"))
            {
                Console.WriteLine("Access Denied");
                return;
            }

            while (true)
            {
                if (role == "admin")
                {
                    Console.WriteLine("\n--- Admin Menu ---");
                    Console.WriteLine("1. Register Customer");
                    Console.WriteLine("2. Add Train");
                    Console.WriteLine("3. Delete Train");
                    Console.WriteLine("4. View All Trains");
                    Console.WriteLine("5. Add Train Class");
                    Console.WriteLine("6. View Train Classes");
                    Console.WriteLine("7. View All Bookings");
                    Console.WriteLine("8. View All Cancellations");
                    Console.WriteLine("9. View Ticket by ID");
                    Console.WriteLine("10. Exit");
                }
                else
                {
                    Console.WriteLine("\n--- User Menu ---");
                    Console.WriteLine("1. Book Ticket");
                    Console.WriteLine("2. Cancel Ticket");
                    Console.WriteLine("3. View Ticket");
                    Console.WriteLine("4. Exit");
                }

                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                // ---- Admin actions ----
                if (role == "admin")
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Customer ID: ");
                            int cid = int.Parse(Console.ReadLine());
                            Console.Write("Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Phone: ");
                            string phone = Console.ReadLine();
                            Console.Write("Email: ");
                            string mail = Console.ReadLine();
                            custService.RegisterCustomer(cid, name, phone, mail);
                            break;

                        case "2":
                            Console.Write("Train No: ");
                            int tno = int.Parse(Console.ReadLine());
                            Console.Write("Train Name: ");
                            string tname = Console.ReadLine();
                            Console.Write("Class: ");
                            string tclass = Console.ReadLine();
                            Console.Write("Cost per seat: ");
                            decimal cost = decimal.Parse(Console.ReadLine());
                            trainService.AddTrain(tno, tname, tclass, cost);
                            break;

                        case "3":
                            Console.Write("Enter Train No to delete: ");
                            int delNo = int.Parse(Console.ReadLine());
                            trainService.DeleteTrain(delNo);
                            break;

                        case "4":
                            trainService.ViewAllTrains();
                            break;

                        case "5":
                            Console.Write("Class Name: ");
                            string cname = Console.ReadLine();
                            Console.Write("Cost per seat: ");
                            decimal ccost = decimal.Parse(Console.ReadLine());
                            trainClassService.AddTrainClass(cname, ccost);
                            break;

                        case "6":
                            trainClassService.ViewTrainClasses();
                            break;

                        case "7":
                            bookingReport.ViewAllBookings();
                            break;

                        case "8":
                            bookingReport.ViewAllCancellations();
                            break;

                        case "9":
                            Console.Write("Booking ID: ");
                            int viewId = int.Parse(Console.ReadLine());
                            resService.PrintTicket(viewId);
                            break;

                        case "10":
                            Console.WriteLine("Exit");
                            return;

                        default:
                            Console.WriteLine("Invalid Option");
                            break;
                    }
                }

                else
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Booking ID: ");
                            int bid = int.Parse(Console.ReadLine());
                            Console.Write("Customer ID: ");
                            int custId = int.Parse(Console.ReadLine());
                            Console.Write("Customer Name: ");
                            string cname = Console.ReadLine();
                            Console.Write("Travel Date (yyyy-mm-dd): ");
                            DateTime tdate = DateTime.Parse(Console.ReadLine());
                            Console.Write("Class: ");
                            string cls = Console.ReadLine();
                            Console.Write("Seats: ");
                            int seats = int.Parse(Console.ReadLine());
                            resService.BookTicket(bid, custId, cname, tdate, cls, seats);
                            break;

                        case "2":
                            Console.Write("Booking ID to cancel: ");
                            int cancelId = int.Parse(Console.ReadLine());
                            cancelService.CancelTicket(cancelId);
                            break;

                        case "3":
                            Console.Write("Booking ID to view: ");
                            int viewId = int.Parse(Console.ReadLine());
                            resService.PrintTicket(viewId);
                            break;

                        case "4":
                            Console.WriteLine("Exit");
                            return;

                        default:
                            Console.WriteLine("Invalid Option");
                            break;
                    }
                }
            }
        }
    }
}
