using ClassLib.Data;
using ClassLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Airline.UnitTests.MockData
{
    class CustomerDalStub : IPersistDal<CustomerDto>, IFetchDal<CustomerDto>
    {
        private List<CustomerDto> customerDtoList = new List<CustomerDto>()
            {
            new CustomerDto(){ customerId=1, firstName="Tom", lastName="Vasel", email="Tem@live.com", phoneNumber="0658475960", dateOfBirth=new DateTime(2001, 5, 3, 0, 00, 00), gender="male", password="AF825CF4AF92B2DC5699F66ED1A4853F5870E7EBF89A4C4A4FF138C39D6109A1", isAdmin=false},
            new CustomerDto(){ customerId=2, firstName="Roos", lastName="dijck", email="Roosje@hart.nl", phoneNumber="0694836745", dateOfBirth=new DateTime(1988, 5, 3, 0, 00, 00), gender="female", password="53B945B392DFC50FBDA2B803A0F9E7388420F094665BD31A1AE22DBC3D1F5482", isAdmin=false},
            new CustomerDto(){ customerId=3, firstName="Willy", lastName="Alex", email="Wellempje@game.net", phoneNumber="0694856384", dateOfBirth=new DateTime(1995, 7, 18, 0, 00, 00), gender="other", password="2AEB9015B14196CCA87359FE32103AC60593D5E9F78793298F001E2225B17877", isAdmin=false}
            };
        public CustomerDto verifyLogin(string email, string password)
        {
            CustomerDto customer = customerDtoList.Single(x => x.email == email);
            if (customer.email == email && customer.password == password)
            {
                return customer;
            }
            throw new CustomerLoginException(string.Format("Unable to find a customer by matching password", email));
        }


        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerDto> getAll() => customerDtoList;
        public CustomerDto getById(int id)
        {
            throw new NotImplementedException();
        }

        public void save(CustomerDto t)
        {
            throw new NotImplementedException();
        }

        public int saveGetId(CustomerDto t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerDto> search(string searchString)
        {
            throw new NotImplementedException();
        }

        public void update(CustomerDto t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerDto> getAllByCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
