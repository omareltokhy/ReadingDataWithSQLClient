﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SqlClientRepoModule2.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
