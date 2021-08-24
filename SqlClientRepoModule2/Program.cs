using Microsoft.Data.SqlClient;
using SqlClientRepoModule2.Models;
using SqlClientRepoModule2.Repository;
using System;
using System.Collections.Generic;

namespace SqlClientRepoModule2
{
    public class Program
    {
        static void Main(string[] args)
        {
            ICustomerRepository repository = new CustomerRepository();
            //TestSelectAll(repository);
            //TestSelectCustomer(repository);
            //TestSelectCustomerByName(repository);
        }

        static void TestSelectAll(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetAllCustomers());
        }
        static void TestSelectCustomer(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomer(1));
        }
        static void TestSelectCustomerByName(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomerByName("Smith"));
        }

        static void PrintCustomers(IEnumerable<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                PrintCustomer(customer);
            }
        }

        public static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"--- { customer.CustomerID} {customer.FirstName} {customer.LastName} {customer.Country} {customer?.PostalCode} {customer?.PhoneNumber} {customer.Email} ---");
        }

    }
}
