using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
     
        string connectionString = "Server=ICS-LT-7Z33D64\\SQLEXPRESS01;Database=we;User Id=sa;Password=Monalipatnaik@123";

    
        int empIdToUpdate = 4;

        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

              
                using (SqlCommand updateCmd = new SqlCommand("UpdatEmployeeSalarys", conn))
                {
                    updateCmd.CommandType = CommandType.StoredProcedure;

                  
                    updateCmd.Parameters.AddWithValue("@EmpId", empIdToUpdate);

                 
                    SqlParameter updatedSalaryParam = new SqlParameter("@UpdatedSalary", SqlDbType.Decimal)
                    {
                        Precision = 10,
                        Scale = 2,
                        Direction = ParameterDirection.Output
                    };
                    updateCmd.Parameters.Add(updatedSalaryParam);

                 
                    updateCmd.ExecuteNonQuery();

                    Console.WriteLine(" Salary updated successfully!");
                    Console.WriteLine(" Updated Salary: ₹" + updatedSalaryParam.Value);
                }

               
                using (SqlCommand selectCmd = new SqlCommand("SELECT * FROM Employee_D WHERE EmpId = @EmpId", conn))
                {
                    selectCmd.Parameters.AddWithValue("@EmpId", empIdToUpdate);

                    using (SqlDataReader reader = selectCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine("\n Employee Details After Update:");
                            Console.WriteLine($" EmpId: {reader["EmpId"]}");
                            Console.WriteLine($" Name: {reader["Name"]}");
                            Console.WriteLine($" Salary: ₹{reader["Salary"]}");
                            Console.WriteLine($" NetSalary: ₹{reader["NetSalary"]}");
                            Console.WriteLine($" Gender: {reader["Gender"]}");
                        }
                        else
                        {
                            Console.WriteLine($" No employee found with EmpId = {empIdToUpdate}");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(" An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}
