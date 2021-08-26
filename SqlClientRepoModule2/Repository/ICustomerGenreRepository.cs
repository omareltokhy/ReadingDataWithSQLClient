using SqlClientRepoModule2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlClientRepoModule2.Repository
{
    interface ICustomerGenreRepository
    {
        public List<CustomerGenre> GetCustomerPopularGenre(int i);
    }
}
