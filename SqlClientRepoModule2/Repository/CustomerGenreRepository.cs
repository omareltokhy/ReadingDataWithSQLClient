using SqlClientRepoModule2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SqlClientRepoModule2.Repository
{
    public class CustomerGenreRepository : ICustomerGenreRepository
    {
        public List<CustomerGenre> GetCustomerPopularGenre(int id)
        {
            List<CustomerGenre> genreList = new List<CustomerGenre>();
            string sql = "SELECT TOP (1) WITH TIES Genre.Name, Customer.FirstName, Customer.LastName, COUNT(Track.TrackId) FROM Genre " +
                "JOIN Track ON Genre.GenreID = Track.GenreID JOIN InvoiceLine ON Track.TrackId = InvoiceLine.TrackId " +
                "JOIN Invoice ON InvoiceLine.InvoiceId = Invoice.InvoiceId " +
                "JOIN Customer ON Invoice.CustomerId = Customer.CustomerId " +
                "WHERE Customer.CustomerID = @CustomerID " +
                "GROUP BY Genre.Name, Customer.FirstName, Customer.LastName " +
                "ORDER BY COUNT(Track.TrackId) DESC";
            try
            {
                using SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring());
                conn.Open();
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CustomerID", id);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerGenre temp = new CustomerGenre
                    {
                        Genre = reader.GetString(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                    };
                    genreList.Add(temp);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return genreList;
        }
    }
}
