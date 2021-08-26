using Microsoft.Data.SqlClient;
using SqlClientRepoModule2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlClientRepoModule2.Repository
{
    class CustomerCountryRepository : ICustomersCountryRepository
    {
        /// <summary>
        /// Gets customers by country from Chinook database and shows how many customers the
        /// country has and prints the results to console in descending order.
        /// </summary>
        /// <returns></returns>
        public List<CustomerCountry> GetCustomersByCountry()
        {
            List<CustomerCountry> list = new List<CustomerCountry>();
            string sql = "SELECT Country, COUNT(Country) FROM Customer GROUP BY Country ORDER BY COUNT(Country) DESC";
            try
            {
                using SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring());
                conn.Open();
                using SqlCommand cmd = new SqlCommand(sql, conn);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerCountry temp = new CustomerCountry()
                    {
                        Country = reader.GetString(0),
                        CountrySum = reader.GetInt32(1),
                    };
                    list.Add(temp);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }
    }
}
