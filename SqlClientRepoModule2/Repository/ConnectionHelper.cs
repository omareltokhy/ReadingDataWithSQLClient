using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlClientRepoModule2.Repository
{
    public class ConnectionHelper
    {
        public static string GetConnectionstring()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = "5CG05206QT\\SQLEXPRESS";
            connectionStringBuilder.InitialCatalog = "Chinook";
            connectionStringBuilder.IntegratedSecurity = true;
            return connectionStringBuilder.ConnectionString;
        }

    }
}
