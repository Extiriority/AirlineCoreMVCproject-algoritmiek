using ClassLib.Interface;
using ClassLib.Interface.Customer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace ClassLib.Data.Customer
{
    public class CustomerDalMsSql : Database, ICustomerPersist, ICustomerFetch
    {
        public void delete(int Id)
        {
            throw new NotImplementedException();
        }

        public void save(CustomerDto data)
        {
            try
            {
                string query = "INSERT INTO Customer (FirstName, LastName, Email, PhoneNumber, DateOfBirth, Gender, Password) " +
                               "VALUES (@firstName, @lastName, @email, @phoneNumber, @dateOfBirth, @gender, @password)";
                databaseConnection(query);

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
                connClose();
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
                string query = "SELECT * FROM Customer " +
                               "WHERE Id = @customerId";
                CustomerDto customer = new CustomerDto();
                
                databaseConnection(query);
                cmd.Parameters.Add("@customerId", System.Data.SqlDbType.Int).Value = Id;
                using (reader = cmd.ExecuteReader())
                using (SqlCommand command = new SqlCommand(query, conn))

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
                return customer;
            }
            finally
            {
                connClose();
            }
        }


        public bool verifyLogin(string email, string password)
        {
            string query = "SELECT CustomerId FROM Customer WHERE Email='" + email + "' AND Password='" + password + "'";
            databaseConnection(query);

            var result = cmd.ExecuteScalar();
            bool trueOrFalse = result != null ? (int)result > 0 : false;
            return trueOrFalse;
        }
    }
}
