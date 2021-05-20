using ClassLib.Interface;
using ClassLib.Interface.Customer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ClassLib.Data.Customer
{
    public class CustomerDalMsSql : ICustomerPersist, ICustomerFetch
    {
        private readonly SqlConnection conn = new SqlConnection(@"Data Source=mssql.fhict.local;Initial Catalog=dbi463189_airline;Persist Security Info=True;User ID=dbi463189_airline;Password=m4VEw2tX;");

        public void delete(int Id)
        {
            throw new NotImplementedException();
        }

        public void save(CustomerDto data)
        {
            try
            {
                this.conn.Open();

                string query = "INSERT INTO Customer (FirstName, LastName, Email, PhoneNumber, DateOfBirth, Gender, Password) " +
                               "VALUES (@firstName, @lastName, @email, @phoneNumber, @dateOfBirth, @gender, @password)";
                SqlCommand cmd = new SqlCommand(query, this.conn);

                cmd.Parameters.AddWithValue("@FirstName", data.firstName);
                cmd.Parameters.AddWithValue("@LastName", data.lastName);
                cmd.Parameters.AddWithValue("@Email", data.email);
                cmd.Parameters.AddWithValue("@PhoneNumber", data.phoneNumber);
                cmd.Parameters.AddWithValue("@DateOfBirth", data.dateOfBirth);
                cmd.Parameters.AddWithValue("@Gender", data.gender);
                cmd.Parameters.AddWithValue("@Password", data.password);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                this.conn.Close();
            }
        }

        public void update(CustomerDto customer)
        {
            throw new NotImplementedException();
        }
        public CustomerDto getById(int Id)
        {
            try
            {
                this.conn.Open();

                string query = "SELECT * FROM Customer " +
                               "WHERE Id = @customerId";
                SqlCommand cmd = new SqlCommand(query, this.conn);

                cmd.Parameters.Add("@customerId", System.Data.SqlDbType.Int).Value = Id;

                using SqlDataReader reader = cmd.ExecuteReader();

                CustomerDto customer = new CustomerDto();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        {
                            customer.customerId = (int)reader["Id"];
                            customer.firstName = Convert.ToString(reader["aircraftCode"]);
                            customer.lastName = Convert.ToString(reader["aircraftType"]);
                            customer.email = Convert.ToString(reader["departureCountry"]);
                            customer.phoneNumber = Convert.ToString(reader["arrivalCountry"]);
                            customer.dateOfBirth = (DateTime)reader["departureDate"];
                            customer.gender = Convert.ToString(reader["arrivalDate"]);
                            customer.password = Convert.ToString(reader["flightStatus"]);
                        };
                    }
                }
                return customer;
            }
            finally
            {
                this.conn.Close();
            }
        }
    }
}
