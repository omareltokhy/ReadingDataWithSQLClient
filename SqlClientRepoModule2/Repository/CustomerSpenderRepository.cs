using SqlClientRepoModule2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SqlClientRepoModule2.Repository
{
    public class CustomerSpenderRepository : ICustomerSpenderRepository
    {
        /// <summary>
        /// A method that gets the highest spenders from the Chinook database and
        /// returns the all the highest spenders in descending order
        /// </summary>
        /// <returns></returns>
        public List<CustomerSpender> GetCustomersBySpendAmount()
        {
            List<CustomerSpender> customerList = new List<CustomerSpender>();
            string sql = "SELECT Total, Customer.FirstName, Customer.LastName, COUNT(Total) FROM Invoice JOIN Customer ON Invoice.CustomerID = Customer.CustomerID GROUP BY Total, Customer.FirstName, Customer.LastName ORDER BY Total DESC";
            try
            {
                using SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring());
                conn.Open();
                using SqlCommand cmd = new SqlCommand(sql, conn);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerSpender temp = new CustomerSpender
                    {
                        Total = reader.GetDecimal(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                    };
                    customerList.Add(temp);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customerList;
        }
    }
}
