using SqlClientRepoModule2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlClientRepoModule2.Repository
{
    public interface ICustomerSpenderRepository
    {
        public List<CustomerSpender> GetCustomersBySpendAmount();
    }
}
