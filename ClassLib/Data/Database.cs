using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ClassLib.Data
{
    public class Database
    {
        private readonly string connectionString;
        public SqlConnection conn;
        public SqlCommand cmd;
        public SqlDataReader reader;


        public Database()
        {
            connectionString = "Data Source=mssql.fhict.local;Initial Catalog=dbi463189_airline;Persist Security Info=True;User ID=dbi463189_airline;Password=m4VEw2tX;";
        }

        public void databaseConnection(string query)
        {
            conn = new System.Data.SqlClient.SqlConnection(connectionString);
            conn.Open();
            cmd = new System.Data.SqlClient.SqlCommand(query, conn);
        }

        public void connClose()
        {
            conn = new System.Data.SqlClient.SqlConnection(connectionString);
            conn.Close();
        }
    }
}
