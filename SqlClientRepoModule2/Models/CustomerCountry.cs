using System;
using System.Collections.Generic;
using System.Text;

namespace SqlClientRepoModule2.Models
{
    public class CustomerCountry
    {
        public Customer Customer { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
