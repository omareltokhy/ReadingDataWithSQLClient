using Microsoft.Data.SqlClient;
using SqlClientRepoModule2.Models;
using SqlClientRepoModule2.Repository;
using System;
using System.Collections.Generic;

namespace SqlClientRepoModule2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ICustomerRepository repository = new CustomerRepository();
            //TestSelectAll(repository);
            //TestSelectCustomer(repository);
            //TestSelectCustomerByName(repository);
            //TestCustomerPage(repository);

            //Customer customer = new Customer()
            //{
            //    FirstName = "Petri",
            //    LastName = "Nygård",
            //    Country = "Finland",
            //    PhoneNumber = "+3584001234567",
            //    PostalCode = "00100",
            //    Email = "petri.nygård@fi.experis.com"
            //};

            Customer newcus = new Customer()
            {
                CustomerID = 60,
                FirstName = "Liisa",
                //LastName = "Nygård",
                //Country = "Finland",
                //Email= "liisa@gmail.com",
                //PhoneNumber = "+358451234567",
                //PostalCode = "00110"
            };

            //TestAddCustomer(repository, customer);

            //TestUpdateCustomer(repository, newcus);

            ICustomersCountryRepository countryRepository = new CustomerCountryRepository();

            TestCustomerCountryDescending(countryRepository);


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

        static void TestCustomerPage(ICustomerRepository repository)
        {
            PrintCustomers(repository.ReturnPageOfCustomers(10, 10));
        }

        static void TestAddCustomer(ICustomerRepository repository, Customer customer)
        {
            PrintCustomer(repository.AddNewCustomer(customer));
        }
        static void TestUpdateCustomer(ICustomerRepository repository, Customer newcus)
        {
            PrintCustomer(repository.UpdateCustomer(newcus));
        }
        static void TestCustomerCountryDescending(ICustomersCountryRepository countryRepository)
        {
            PrintCustomersBy(countryRepository.GetCustomersByCountry());
        }

        static void PrintCustomersBy(IEnumerable<CustomerCountry> customerCountries)
        {
            foreach (CustomerCountry country in customerCountries)
            {
                Console.WriteLine($"{country.Country} ({country.CountrySum})");
            }
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
