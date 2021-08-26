using Microsoft.Data.SqlClient;
using SqlClientRepoModule2.Models;
using SqlClientRepoModule2.Repository;
using System;
using System.Collections.Generic;

namespace SqlClientRepoModule2
{
    public class Program
    {
        /// <summary>
        /// Contains test calls for functions
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {

            ICustomerRepository repository = new CustomerRepository();
            ICustomersCountryRepository countryRepository = new CustomerCountryRepository();
            ICustomerSpenderRepository spenderRepository = new CustomerSpenderRepository();
            ICustomerGenreRepository genreRepository = new CustomerGenreRepository();
            
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

            //Customer newcus = new Customer()
            //{
            //    CustomerID = 60,
            //    FirstName = "Liisa",
            //};

            //TestAddCustomer(repository, customer);
            //TestUpdateCustomerFirstName(repository, newcus);
            //TestCustomerCountryDescending(countryRepository);
            //TestCustomerSpendersDescending(spenderRepository);
            //TestCustomerPopularGenreDescending(genreRepository, 12);

        }
        /// <summary>
        /// Contains nine test methods to test the functionality of all methods in
        ///the repository folder.
        /// </summary>
        /// <param name="repository"></param>
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
        static void TestUpdateCustomerFirstName(ICustomerRepository repository, Customer newcus)
        {
            PrintCustomer(repository.UpdateCustomerFirstName(newcus));
        }
        static void TestCustomerCountryDescending(ICustomersCountryRepository countryRepository)
        {
            PrintCustomersBy(countryRepository.GetCustomersByCountry());
        }
        static void TestCustomerSpendersDescending(ICustomerSpenderRepository spenderRepository)
        {
            PrintCustomersBySpender(spenderRepository.GetCustomersBySpendAmount());
        }
        static void TestCustomerPopularGenreDescending(ICustomerGenreRepository genreRepository, int id)
        {
            PrintCustomerByPopularGenre(genreRepository.GetCustomerPopularGenre(id));
        }
        /// <summary>
        /// Five Separate printing methods to use in the testing methods.
        /// </summary>
        /// <param name="customerCountries"></param>
        static void PrintCustomersBy(IEnumerable<CustomerCountry> customerCountries)
        {
            foreach (CustomerCountry country in customerCountries)
            {
                Console.WriteLine($"{country.Country} ({country.CountrySum})");
            }
        }
        static void PrintCustomersBySpender(IEnumerable<CustomerSpender> customerSpenders)
        {
            foreach (CustomerSpender spender in customerSpenders)
            {
                Console.WriteLine($"Person: ({spender.FirstName} {spender.LastName}) has total Invoice sum: ({spender.Total})");
            }
        }
        static void PrintCustomerByPopularGenre(IEnumerable<CustomerGenre> customerGenres)
        {
            bool first = true;
            foreach (CustomerGenre genre in customerGenres)
            {
                if (first)
                {
                    Console.Write($"Person: ({genre.FirstName} {genre.LastName}) favourite genre of music is: ");
                    first = false;
                }
                Console.Write($"{genre.Genre} ");
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
