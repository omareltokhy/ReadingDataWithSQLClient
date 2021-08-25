using SqlClientRepoModule2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlClientRepoModule2.Repository
{
    public interface ICustomersCountryRepository
    {
        public List<CustomerCountry> GetCustomersByCountry();
    }
}
