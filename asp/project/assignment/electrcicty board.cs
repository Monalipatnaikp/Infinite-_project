using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBUtility; 

namespace ElectricityBillingProject
{
    public class ElectricityBoard
    {
        public void AddBill(ElectricityBill ebill)
        {
            using (SqlConnection conn = new DBHandler().GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO ElectricityBill (consumer_number, consumer_name, units_consumed, bill_amount) " +
                               "VALUES (@consumerNumber, @consumerName, @unitsConsumed, @billAmount)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@consumerNumber", ebill.ConsumerNumber);
                    cmd.Parameters.AddWithValue("@consumerName", ebill.ConsumerName);
                    cmd.Parameters.AddWithValue("@unitsConsumed", ebill.UnitsConsumed);
                    cmd.Parameters.AddWithValue("@billAmount", ebill.BillAmount);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CalculateBill(ElectricityBill ebill)
        {
            int units = ebill.UnitsConsumed;
            double amount = 0;

            if (units > 1000)
            {
                amount += (units - 1000) * 7.5;
                units = 1000;
            }
            if (units > 600)
            {
                amount += (units - 600) * 5.5;
                units = 600;
            }
            if (units > 300)
            {
                amount += (units - 300) * 3.5;
                units = 300;
            }
            if (units > 100)
            {
                amount += (units - 100) * 1.5;
                units = 100;
            }
            // First 100 are free

            ebill.BillAmount = amount;
        }

        public List<ElectricityBill> Generate_N_BillDetails(int num)
        {
            List<ElectricityBill> bills = new List<ElectricityBill>();
            using (SqlConnection conn = new DBHandler().GetConnection())
            {
                conn.Open();
                string query = "SELECT TOP (@num) * FROM ElectricityBill ORDER BY consumer_number DESC"; // Assuming consumer_number is sequential for "last N"
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@num", num);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ElectricityBill bill = new ElectricityBill
                            {
                                ConsumerNumber = reader["consumer_number"].ToString(),
                                ConsumerName = reader["consumer_name"].ToString(),
                                UnitsConsumed = Convert.ToInt32(reader["units_consumed"]),
                                BillAmount = Convert.ToDouble(reader["bill_amount"])
                            };
                            bills.Add(bill);
                        }
                    }
                }
            }
            return bills;
        }
    }
}
