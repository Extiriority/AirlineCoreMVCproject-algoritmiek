using ClassLib.Interface;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;


namespace ClassLib.Data.Customer
{
    public class CustomerDalMsSql : IPersistDal<CustomerDto>, IFetchDal<CustomerDto>
    {

        public void save(CustomerDto data)
        {
            Database.execute(
                "INSERT INTO Customer (FirstName, LastName, Email, PhoneNumber, DateOfBirth, Gender, Password) VALUES (@firstName, @lastName, @email, @phoneNumber, @dateOfBirth, @gender, @password)",
                new
                {
                    data.firstName,
                    data.lastName,
                    data.email,
                    data.phoneNumber,
                    data.dateOfBirth,
                    data.gender,
                    data.password
                }
            );  
        }

        public CustomerDto getById(int customerId)
        {
            var result = Database.query<CustomerDto>(
                "SELECT * FROM Customer WHERE CustomerId = @customerId",
                new
                {
                    customerId
                }
            ).ToImmutableList();

            return result.Count != 1 ? null : result.Single();
        }

        public bool verifyLogin(string email, string password)
        {
            return Database.query<bool>(
                "SELECT CustomerId FROM Customer WHERE Email='" + email + "' AND Password='" + password + "'",
                new
                {
                    email,
                    password
                }
            ).Single();
        }


        public void delete(int Id)
        {
            throw new NotImplementedException();
        }
        public void update(CustomerDto customer)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<CustomerDto> getAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerDto> search(string searchString)
        {
            throw new NotImplementedException();
        }
    }
}
