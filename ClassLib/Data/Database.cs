using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ClassLib.Data
{
    public class Database
    {
        

        private static readonly SqlConnection connection =
             new SqlConnection("Data Source=mssql.fhict.local;Initial Catalog=dbi463189_airline;Persist Security Info=True;User ID=dbi463189_airline;Password=m4VEw2tX;");

         static Database()
         {
             connection.Open();
         }

         public static IEnumerable<T> query<T>(string sql, object parameters = null)
         {
             return connection.Query<T>(sql, parameters);
         }

         public static int execute(string sql, object parameters = null)
         {
             return connection.Execute(sql, parameters);
         }

        public static int executeScalar(string sql, object parameters = null)
        {
            return connection.ExecuteScalar<Int32>(sql, parameters);
        }
    }
}
