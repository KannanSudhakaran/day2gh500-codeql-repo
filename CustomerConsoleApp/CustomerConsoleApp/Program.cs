using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CustomerDbSampleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CaseStudy1();


        }

        private static void CaseStudy1()
        {
            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=klinedb1;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("connected successfully to " + connection.Database);
                string customerId = "";
                Console.WriteLine("Enter cusotmer id ");
                customerId = Console.ReadLine();
                String customerByIdQuery = "select * from customers where id=" + customerId;
                SqlCommand cmd = new SqlCommand(customerByIdQuery, connection);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Console.WriteLine("{0} {1} {2} ", dr["id"], dr["name"], dr["job"]);
                    }
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}