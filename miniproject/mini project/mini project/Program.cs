using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RailwayReservationSystem
{
    class Program
    {
        private static readonly string connectionString = "Server=ICS-LT-7Z33D64\\SQLEXPRESS01;Database=railwaydbb;user id=sa;password=Monalipatnaik@123;";

        static void Main()
        {
            var db = new DbHelper();
            var trainSvc = new TrainService();
            var classSvc = new TrainClassService();
            var resSvc = new ReservationService();
            var cancelSvc = new CancellationService();

            while (true) // Outer loop for login/logout
            {
                Console.Write("admin/user: ");
                string role = Console.ReadLine()?.Trim().ToLower() ?? "user";
                Console.Write("Enter password: ");
                string pwd = Console.ReadLine();
                if ((role == "admin" && pwd != "admin123") || (role == "user" && pwd != "user123"))
                {
                    Console.WriteLine("Access Denied");
                    return;
                }

                bool loggedIn = true;
                while (loggedIn)
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
                        Console.WriteLine("7. View All Reservations");
                        Console.WriteLine("8. View All Cancellations");
                        Console.WriteLine("9. Logout");
                        Console.WriteLine("10. Exit");
                        Console.Write("Choose: ");
                        string ch = Console.ReadLine();

                        if (ch == "1")
                        {
                            Console.Write("Customer ID: "); int cid = int.Parse(Console.ReadLine());
                            Console.Write("Name: "); string nm = Console.ReadLine();
                            Console.Write("Phone: "); string ph = Console.ReadLine();
                            Console.Write("Email: "); string mail = Console.ReadLine();
                            db.ExecuteNonQuery("INSERT INTO Customerss (CustID, CustName, Phone, MailID) VALUES (@id,@name,@phone,@mail)",
                                new Dictionary<string, object> { { "@id", cid }, { "@name", nm }, { "@phone", ph }, { "@mail", mail } });
                            Console.WriteLine("Customer added.");
                        }
                        else if (ch == "2")
                        {
                            Console.Write("Name: "); string tn = Console.ReadLine();
                            Console.Write("Source: "); string src = Console.ReadLine();
                            Console.Write("Destination: "); string dest = Console.ReadLine();
                            Console.Write("Departure (yyyy-MM-dd HH:mm): "); DateTime dep = DateTime.Parse(Console.ReadLine());
                            Console.Write("Arrival (yyyy-MM-dd HH:mm): "); DateTime arr = DateTime.Parse(Console.ReadLine());
                            Console.Write("Total seats: "); int tot = int.Parse(Console.ReadLine());
                            trainSvc.AddTrain(tn, src, dest, dep, arr, tot);
                        }
                        else if (ch == "3")
                        {
                            Console.Write("TrainID to delete: "); int tid = int.Parse(Console.ReadLine());
                            trainSvc.DeleteTrain(tid);
                        }
                        else if (ch == "4") trainSvc.ViewAllTrains();
                        else if (ch == "5")
                        {
                            Console.Write("TrainID: "); int tid = int.Parse(Console.ReadLine());
                            Console.Write("ClassName: "); string cls = Console.ReadLine();
                            Console.Write("SeatCount: "); int sc = int.Parse(Console.ReadLine());
                            Console.Write("Fare: "); decimal fare = decimal.Parse(Console.ReadLine());
                            classSvc.AddTrainClass(tid, cls, sc, fare);
                        }
                        else if (ch == "6") classSvc.ViewTrainClasses();
                        else if (ch == "7") ViewAllReservations();
                        else if (ch == "8") ViewAllCancellations();
                        else if (ch == "9")
                        {
                            Console.WriteLine("Logged out successfully.");
                            loggedIn = false;
                            Console.Clear();
                        }
                        else if (ch == "10")
                        {
                            Console.WriteLine("Exiting program...");
                            return; // Terminate the program
                        }
                        else Console.WriteLine("Invalid choice.");
                    }
                    else if (role == "user")
                    {
                        Console.WriteLine("\n--- User Menu ---");
                        Console.WriteLine("1. Book Ticket");
                        Console.WriteLine("2. Print Ticket");
                        Console.WriteLine("3. Cancel Ticket");
                        Console.WriteLine("4. Logout");
                        Console.WriteLine("5. Show Registered Customers");
                        Console.WriteLine("6. Exit");
                        Console.Write("Choose: ");
                        string ch = Console.ReadLine();

                        if (ch == "1")
                        {
                            Console.Write("Booking ID: "); int bid = int.Parse(Console.ReadLine());
                            Console.Write("Customer ID: "); int cid = int.Parse(Console.ReadLine());
                            Console.Write("Customer Name: "); string cname = Console.ReadLine();
                            Console.Write("Train ID: "); int tid = int.Parse(Console.ReadLine());
                            Console.Write("Travel Date (yyyy-MM-dd): "); DateTime tdate = DateTime.Parse(Console.ReadLine());
                            Console.Write("Class: "); string cls = Console.ReadLine();
                            Console.Write("Seats: "); int seats = int.Parse(Console.ReadLine());
                            resSvc.BookTicket(bid, cid, cname, tid, tdate, cls, seats);
                        }
                        else if (ch == "2")
                        {
                            Console.Write("Booking ID: "); int bid = int.Parse(Console.ReadLine());
                            resSvc.PrintTicket(bid);
                        }
                        else if (ch == "3")
                        {
                            Console.Write("Booking ID to cancel: "); int bid = int.Parse(Console.ReadLine());
                            cancelSvc.CancelTicket(bid);
                        }
                        else if (ch == "4")
                        {
                            Console.WriteLine("Logged out successfully.");
                            loggedIn = false;
                            Console.Clear();
                        }
                        else if (ch == "5")
                        {
                            ViewAllCustomers();
                        }
                        else if (ch == "6")
                        {
                            Console.WriteLine("Exiting program...");
                            return; // Terminate the program
                        }
                        else Console.WriteLine("Invalid choice.");
                    }
                }
            }
        }
        static void ViewAllReservations()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT BookingID, CustNo, CustName, TrainID, TravelDate, Class, SeatsBooked, TotalCost, BookingDate
                                 FROM Reservation";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    Console.WriteLine("No reservations found.");
                    return;
                }

                Console.WriteLine("\nAll Reservations:");
                Console.WriteLine("BookingID | CustNo | CustName | TrainID | TravelDate | Class | Seats | TotalCost | BookingDate");
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine($"{row["BookingID"],-9} | {row["CustNo"],-6} | {row["CustName"],-18} | {row["TrainID"],-7} | {Convert.ToDateTime(row["TravelDate"]):yyyy-MM-dd} | {row["Class"],-7} | {row["SeatsBooked"],-5} | ₹{row["TotalCost"],-9} | {Convert.ToDateTime(row["BookingDate"]):yyyy-MM-dd}");
                }
            }
        }

        static void ViewAllCancellations()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT c.BID AS BookingID, c.TicketCancelled, c.RefundAmount, c.CancellationDate,
                                        r.CustName, r.TrainID, r.Class, r.SeatsBooked
                                 FROM Cancellation c
                                 LEFT JOIN Reservation r ON c.BID = r.BookingID";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    Console.WriteLine("No cancellations found.");
                    return;
                }

                Console.WriteLine("\nAll Cancellations:");
                Console.WriteLine("BookingID | TicketCancelled | RefundAmount | CancellationDate | CustName | TrainID | Class | Seats");
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine($"{row["BookingID"],-9} | {row["TicketCancelled"],-15} | ₹{row["RefundAmount"],-11} | {Convert.ToDateTime(row["CancellationDate"]):yyyy-MM-dd} | {row["CustName"],-18} | {row["TrainID"],-7} | {row["Class"],-7} | {row["SeatsBooked"],-5}");
                }
            }
        }

        static void ViewAllCustomers()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT CustID, CustName, Phone, MailID FROM Customerss";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    Console.WriteLine("No customers found.");
                    return;
                }

                Console.WriteLine("\nAll Registered Customers:");
                Console.WriteLine("CustID | CustName | Phone      | MailID");
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine($"{row["CustID"],-6} | {row["CustName"],-18} | {row["Phone"],-10} | {row["MailID"]}");
                }
            }
        }
    }

    public class DbHelper
    {
        public string ConnectionString { get; } = "Server=ICS-LT-7Z33D64\\SQLEXPRESS01;Database=railwaydbb;user id=sa;password=Monalipatnaik@123;";

        public void ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (parameters != null)
                    foreach (var p in parameters)
                        cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (parameters != null)
                    foreach (var p in parameters)
                        cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }

    public class TrainService
    {
        private readonly DbHelper db = new DbHelper();

        public void AddTrain(string name, string source, string dest, DateTime dep, DateTime arr, int totalSeats)
        {
            string query = @"INSERT INTO Train (TrainName, Source, Destination, DepartureTime, ArrivalTime, TotalSeats, AvailableSeats)
                             VALUES (@name, @src, @dest, @dep, @arr, @total, @avail)";
            db.ExecuteNonQuery(query, new Dictionary<string, object> {
                {"@name", name},
                {"@src", source},
                {"@dest", dest},
                {"@dep", dep},
                {"@arr", arr},
                {"@total", totalSeats},
                {"@avail", totalSeats}
            });
            Console.WriteLine("Train added.");
        }

        public void DeleteTrain(int trainId)
        {
            var reservations = db.ExecuteQuery("SELECT 1 FROM Reservation WHERE TrainID = @tid", new Dictionary<string, object> { { "@tid", trainId } });
            if (reservations.Rows.Count > 0)
            {
                Console.WriteLine("Cannot delete: there are existing reservations for this train.");
                return;
            }
            db.ExecuteNonQuery("DELETE FROM TrainClasses WHERE TrainID = @tid", new Dictionary<string, object> { { "@tid", trainId } });
            db.ExecuteNonQuery("DELETE FROM Train WHERE TrainID = @tid", new Dictionary<string, object> { { "@tid", trainId } });
            Console.WriteLine("Train deleted.");
        }

        public void ViewAllTrains()
        {
            var dt = db.ExecuteQuery("SELECT TrainID, TrainName, Source, Destination, DepartureTime, ArrivalTime, TotalSeats, AvailableSeats FROM Train");
            Console.WriteLine("\nTrainID | Name                 | Source -> Destination | Dep               | Arr               | AvailSeats");
            foreach (DataRow r in dt.Rows)
            {
                Console.WriteLine($"{r["TrainID"],-7} | {r["TrainName"],-20} | {r["Source"]} -> {r["Destination"],-15} | {Convert.ToDateTime(r["DepartureTime"]):yyyy-MM-dd HH:mm} | {Convert.ToDateTime(r["ArrivalTime"]):yyyy-MM-dd HH:mm} | {r["AvailableSeats"]}");
            }
        }
    }

    public class TrainClassService
    {
        private readonly DbHelper db = new DbHelper();

        public void AddTrainClass(int trainId, string className, int seatCount, decimal fare)
        {
            var t = db.ExecuteQuery("SELECT 1 FROM Train WHERE TrainID = @tid", new Dictionary<string, object> { { "@tid", trainId } });
            if (t.Rows.Count == 0) { Console.WriteLine("Train not found."); return; }

            db.ExecuteNonQuery(@"INSERT INTO TrainClasses (TrainID, ClassName, SeatCount, Fare)
                                 VALUES (@tid, @cls, @seat, @fare)", new Dictionary<string, object>
            {
                {"@tid", trainId},
                {"@cls", className},
                {"@seat", seatCount},
                {"@fare", fare}
            });
            Console.WriteLine("Class added.");
        }

        public void ViewTrainClasses()
        {
            var dt = db.ExecuteQuery(@"SELECT tc.TrainID, t.TrainName, tc.ClassName, tc.SeatCount, tc.Fare
                                       FROM TrainClasses tc
                                       JOIN Train t ON tc.TrainID = t.TrainID");
            Console.WriteLine("\nTrainID | TrainName            | Class      | Seats | Fare");
            foreach (DataRow r in dt.Rows)
                Console.WriteLine($"{r["TrainID"],-7} | {r["TrainName"],-20} | {r["ClassName"],-10} | {r["SeatCount"],-5} | {r["Fare"]}");
        }
    }

    public class ReservationService
    {
        private readonly DbHelper db = new DbHelper();

        public void BookTicket(int bookingId, int custId, string custName, int trainId, DateTime travelDate, string classType, int seats)
        {
            using (SqlConnection conn = new SqlConnection(db.ConnectionString))
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            "SELECT SeatCount, Fare FROM TrainClasses WHERE TrainID = @tid AND ClassName = @class", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@tid", trainId);
                            cmd.Parameters.AddWithValue("@class", classType);
                            using (SqlDataReader rdr = cmd.ExecuteReader())
                            {
                                if (!rdr.Read())
                                {
                                    Console.WriteLine("Class not found for this train.");
                                    tx.Rollback();
                                    return;
                                }
                                int availClassSeats = Convert.ToInt32(rdr["SeatCount"]);
                                decimal fare = Convert.ToDecimal(rdr["Fare"]);
                                rdr.Close();

                                if (availClassSeats < seats)
                                {
                                    Console.WriteLine($"Not enough seats in class {classType}. Available: {availClassSeats}");
                                    tx.Rollback();
                                    return;
                                }

                                using (SqlCommand cmd2 = new SqlCommand("SELECT AvailableSeats FROM Train WHERE TrainID = @tid", conn, tx))
                                {
                                    cmd2.Parameters.AddWithValue("@tid", trainId);
                                    object o = cmd2.ExecuteScalar();
                                    if (o == null)
                                    {
                                        Console.WriteLine("Train not found.");
                                        tx.Rollback();
                                        return;
                                    }
                                    int trainAvail = Convert.ToInt32(o);
                                    if (trainAvail < seats)
                                    {
                                        Console.WriteLine($"Not enough total seats on train. Available: {trainAvail}");
                                        tx.Rollback();
                                        return;
                                    }
                                }

                                decimal totalCost = fare * seats;
                                DateTime bookingDate = DateTime.Now;
                                using (SqlCommand ins = new SqlCommand(
                                    @"INSERT INTO Reservation (BookingID, CustNo, TrainID, CustName, TravelDate, Class, SeatsBooked, TotalCost, BookingDate)
                                      VALUES (@bid, @cid, @tid, @name, @tdate, @class, @seats, @cost, @bdate)", conn, tx))
                                {
                                    ins.Parameters.AddWithValue("@bid", bookingId);
                                    ins.Parameters.AddWithValue("@cid", custId);
                                    ins.Parameters.AddWithValue("@tid", trainId);
                                    ins.Parameters.AddWithValue("@name", custName);
                                    ins.Parameters.AddWithValue("@tdate", travelDate);
                                    ins.Parameters.AddWithValue("@class", classType);
                                    ins.Parameters.AddWithValue("@seats", seats);
                                    ins.Parameters.AddWithValue("@cost", totalCost);
                                    ins.Parameters.AddWithValue("@bdate", bookingDate);
                                    ins.ExecuteNonQuery();
                                }

                                using (SqlCommand updClass = new SqlCommand(
                                    "UPDATE TrainClasses SET SeatCount = SeatCount - @seats WHERE TrainID = @tid AND ClassName = @class", conn, tx))
                                {
                                    updClass.Parameters.AddWithValue("@seats", seats);
                                    updClass.Parameters.AddWithValue("@tid", trainId);
                                    updClass.Parameters.AddWithValue("@class", classType);
                                    updClass.ExecuteNonQuery();
                                }

                                using (SqlCommand updTrain = new SqlCommand(
                                    "UPDATE Train SET AvailableSeats = AvailableSeats - @seats WHERE TrainID = @tid", conn, tx))
                                {
                                    updTrain.Parameters.AddWithValue("@seats", seats);
                                    updTrain.Parameters.AddWithValue("@tid", trainId);
                                    updTrain.ExecuteNonQuery();
                                }

                                tx.Commit();
                                Console.WriteLine("Booking successful");
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        try { tx.Rollback(); } catch { }
                        Console.WriteLine("Error while booking:");
                        return;
                    }
                }
            }
        }

        public void PrintTicket(int bookingId)
        {
            var dt = db.ExecuteQuery("SELECT * FROM Reservation WHERE BookingID = @bid", new Dictionary<string, object> { { "@bid", bookingId } });
            if (dt.Rows.Count == 0) { Console.WriteLine("Ticket not found."); return; }
            var r = dt.Rows[0];
            Console.WriteLine("\nTicket:");
            Console.WriteLine($"BookingID: {r["BookingID"]}");
            Console.WriteLine($"Customer: {r["CustName"]} ({r["CustNo"]})");
            Console.WriteLine($"TrainID: {r["TrainID"]}");
            Console.WriteLine($"TravelDate: {Convert.ToDateTime(r["TravelDate"]):yyyy-MM-dd}");
            Console.WriteLine($"Class: {r["Class"]}");
            Console.WriteLine($"Seats: {r["SeatsBooked"]}");
            Console.WriteLine($"TotalCost: ₹{r["TotalCost"]}");
            Console.WriteLine($"BookingDate: {Convert.ToDateTime(r["BookingDate"]):yyyy-MM-dd}");
        }
    }

    public class CancellationService
    {
        private readonly DbHelper db = new DbHelper();
        public void CancelTicket(int bookingId)
        {
            var dt = db.ExecuteQuery("SELECT TotalCost, SeatsBooked, TrainID, Class FROM Reservation WHERE BookingID = @bid", new Dictionary<string, object> { { "@bid", bookingId } });
            if (dt.Rows.Count == 0) { Console.WriteLine("Booking not found."); return; }
            var row = dt.Rows[0];
            decimal totalCost = Convert.ToDecimal(row["TotalCost"]);
            int seats = Convert.ToInt32(row["SeatsBooked"]);
            int trainId = Convert.ToInt32(row["TrainID"]);
            string cls = Convert.ToString(row["Class"]);
            decimal refund = totalCost * 0.5m;
            DateTime cancelDate = DateTime.Now;

            using (SqlConnection conn = new SqlConnection(db.ConnectionString))
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand ins = new SqlCommand(
                            "INSERT INTO Cancellation (BID, TicketCancelled, RefundAmount, CancellationDate) VALUES (@bid, 1, @refund, @date)", conn, tx))
                        {
                            ins.Parameters.AddWithValue("@bid", bookingId);
                            ins.Parameters.AddWithValue("@refund", refund);
                            ins.Parameters.AddWithValue("@date", cancelDate);
                            ins.ExecuteNonQuery();
                        }
                        using (SqlCommand updClass = new SqlCommand(
                            "UPDATE TrainClasses SET SeatCount = SeatCount + @seats WHERE TrainID = @tid AND ClassName = @class", conn, tx))
                        {
                            updClass.Parameters.AddWithValue("@seats", seats);
                            updClass.Parameters.AddWithValue("@tid", trainId);
                            updClass.Parameters.AddWithValue("@class", cls);
                            updClass.ExecuteNonQuery();
                        }
                        using (SqlCommand updTrain = new SqlCommand(
                            "UPDATE Train SET AvailableSeats = AvailableSeats + @seats WHERE TrainID = @tid", conn, tx))
                        {
                            updTrain.Parameters.AddWithValue("@seats", seats);
                            updTrain.Parameters.AddWithValue("@tid", trainId);
                            updTrain.ExecuteNonQuery();
                        }
                        using (SqlCommand del = new SqlCommand("DELETE FROM Reservation WHERE BookingID = @bid", conn, tx))
                        {
                            del.Parameters.AddWithValue("@bid", bookingId);
                            del.ExecuteNonQuery();
                        }
                        tx.Commit();
                        Console.WriteLine($"Cancelled. Refund: ₹{refund}");
                    }
                    catch (Exception ex)
                    {
                        try { tx.Rollback(); } catch { }
                        Console.WriteLine("Cancellation failed: ");
                    }
                }
            }
        }
    }
}