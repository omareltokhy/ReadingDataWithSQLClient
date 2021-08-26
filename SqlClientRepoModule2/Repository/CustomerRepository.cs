using Microsoft.Data.SqlClient;
using SqlClientRepoModule2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SqlClientRepoModule2.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// A method that inserts a new customer into database with values of firstname, lastname,
        /// country, email, phone and postal code. Returns customer info to console.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public Customer AddNewCustomer(Customer customer)
        {
            string sql = "INSERT INTO Customer (FirstName, LastName, Country, Email, Phone, PostalCode) VALUES (@FirstName, @LastName, @Country, @Email, @PhoneNumber, @PostalCode)";
            try
            {
                using SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring());
                conn.Open();
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@Country", customer.Country);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customer;
        }
        /// <summary>
        /// A method that gets all customers from the database and returns their CustomerID,
        /// FirstName, LastName, Country, Email, Phone and PostalCode to console.
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customerList = new List<Customer>();
            string sql = "SELECT CustomerID, FirstName, LastName, Country, Email, Phone, PostalCode FROM Customer";
            try
            {
                using SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring());
                conn.Open();
                using SqlCommand cmd = new SqlCommand(sql, conn);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer temp = new Customer
                    {
                        CustomerID = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Country = reader.GetString(3),
                        Email = reader.GetString(4),
                        PhoneNumber = reader.IsDBNull("Phone") ? null : reader.GetString(5),
                        PostalCode = reader.IsDBNull("PostalCode") ? null : reader.GetString(6)
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
        /// <summary>
        /// A method that returns a specifies customer info from database by customers id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer GetCustomer(int id)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerID, FirstName, LastName, Country, Email, Phone, PostalCode FROM Customer"
                + " WHERE CustomerID = @CustomerID";
            try
            {
                using SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring());
                conn.Open();
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CustomerID", id);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customer.CustomerID = reader.GetInt32(0);
                    customer.FirstName = reader.GetString(1);
                    customer.LastName = reader.GetString(2);
                    customer.Country = reader.GetString(3);
                    customer.Email = reader.GetString(4);
                    customer.PhoneNumber = reader.IsDBNull("Phone") ? null : reader.GetString(5);
                    customer.PostalCode = reader.IsDBNull("PostalCode") ? null : reader.GetString(6);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customer;
        }
        /// <summary>
        /// A method that returns a specifies customer info from database by customers name. Responds
        /// to partial matches of the name too.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Customer GetCustomerByName(string name)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerID, FirstName, LastName, Country, Email, Phone, PostalCode FROM Customer"
                + " WHERE FirstName LIKE @Name OR LastName LIKE @Name";
            try
            {
                using SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring());
                conn.Open();
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customer.CustomerID = reader.GetInt32(0);
                    customer.FirstName = reader.GetString(1);
                    customer.LastName = reader.GetString(2);
                    customer.Country = reader.GetString(3);
                    customer.Email = reader.GetString(4);
                    customer.PhoneNumber = reader.IsDBNull("Phone") ? null : reader.GetString(5);
                    customer.PostalCode = reader.IsDBNull("PostalCode") ? null : reader.GetString(6);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customer;
        }
        /// <summary>
        /// Returns a page of customers. With parameters you can specify from where you
        /// want to start the list and where you want to end.
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public List<Customer> ReturnPageOfCustomers(int limit, int offset)
        {
            List<Customer> customerList = new List<Customer>();
            string sql = "SELECT CustomerID, FirstName, LastName, Country, Email, Phone, PostalCode FROM Customer"
                + " ORDER BY CustomerID" + " OFFSET @offset ROWS" + " FETCH NEXT @limit ROWS ONLY";
            try
            {
                using SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring());
                conn.Open();
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@offset", offset);
                cmd.Parameters.AddWithValue("@limit", limit);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer temp = new Customer
                    {
                        CustomerID = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Country = reader.GetString(3),
                        Email = reader.GetString(4),
                        PhoneNumber = reader.IsDBNull("Phone") ? null : reader.GetString(5),
                        PostalCode = reader.IsDBNull("PostalCode") ? null : reader.GetString(6)
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
        /// <summary>
        /// Updates customers first name in the database by CustomerId. 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public Customer UpdateCustomerFirstName(Customer customer)
        {
            string sql = "UPDATE Customer SET FirstName = @NewFirstName WHERE CustomerID = @CustomerID";

            try
            {
                using SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring());
                conn.Open();
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@NewFirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customer;
        }
    }
}
