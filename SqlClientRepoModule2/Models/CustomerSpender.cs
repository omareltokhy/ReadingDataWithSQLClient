using System;
using System.Collections.Generic;
using System.Text;

namespace SqlClientRepoModule2.Models
{
    public class CustomerSpender
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? Total { get; set; }
    }
}
