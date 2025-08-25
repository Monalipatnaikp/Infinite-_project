using System;
using System.Data.SqlClient;
using System.Configuration;

namespace assignment
{
    public class DBHandler
    {
        public SqlConnection GetConnection()
        {
            string connString = ConfigurationManager.ConnectionStrings["ElectricityBillDBConnection"].ConnectionString;
            return new SqlConnection(connString);
        }
    }
}
