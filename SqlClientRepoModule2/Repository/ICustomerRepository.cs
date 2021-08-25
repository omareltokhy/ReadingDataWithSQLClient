using SqlClientRepoModule2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlClientRepoModule2.Repository
{
    interface ICustomerRepository
    {
        public Customer GetCustomer(int id);
        public List<Customer> GetAllCustomers();
        public Customer GetCustomerByName(string name);
        public List<Customer>ReturnPageOfCustomers(int limit, int offset);
        public Customer AddNewCustomer(Customer customer);
        public Customer UpdateCustomer(Customer customer);
        //public List<Customer> GetCustomersByCountry();
        public List<Customer> GetHighestSpender();
        public List<Customer> GetMostPopularGenre();

    }
}
