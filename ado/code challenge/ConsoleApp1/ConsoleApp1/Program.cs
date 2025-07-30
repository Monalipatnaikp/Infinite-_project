using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
       
        string connectionString = "Server=ICS-LT-7Z33D64\\SQLEXPRESS01;Database=we;user id =sa;password=Monalipatnaik@123";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand("InsertEmployeeDetails", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", "Monali");
                cmd.Parameters.AddWithValue("@GivenSalary", 90000.00m);
                cmd.Parameters.AddWithValue("@Gender", "Female");

              
                SqlParameter empIdParam = new SqlParameter("@GeneratedEmpId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(empIdParam);

                SqlParameter salaryParam = new SqlParameter("@CalculatedSalary", SqlDbType.Decimal)
                {
                    Precision = 10,
                    Scale = 2,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(salaryParam);

                SqlParameter netSalaryParam = new SqlParameter("@CalculatedNetSalary", SqlDbType.Decimal)
                {
                    Precision = 10,
                    Scale = 2,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(netSalaryParam);

              
                cmd.ExecuteNonQuery();
                Console.WriteLine(" Employee Inserted Successfully!");
                Console.WriteLine("Generated EmpId: " + empIdParam.Value);
                Console.WriteLine("Calculated Salary: ₹" + salaryParam.Value);
                Console.WriteLine("Net Salary: ₹" + netSalaryParam.Value);
            }
        }
    }
}
