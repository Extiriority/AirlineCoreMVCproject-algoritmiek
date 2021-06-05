using ClassLib.Interface;
using ClassLib.Interface.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Logic
{
    public class Customer
    {
        public ICustomerPersist customer;
        public Customer(ICustomerPersist customer)
        {
            this.customer = customer;
        }
        public CustomerDto data { get; }

        public Customer(CustomerDto customerDto)
        {
            data = customerDto;
        }
        public int customerId => data.customerId;
        public string firstName => data.firstName;
        public string lastName => data.lastName;
        public string email => data.email;
        public string phoneNumber => data.phoneNumber;
        public DateTime dateOfBirth => data.dateOfBirth;
        public string gender => data.gender;
        public string password => data.password;

        public void save(Customer customer) => this.customer.save(customer.data);
        public void update(Customer customer) => this.customer.update(customer.data);       
        public void delete(int id) => customer.delete(id);
    }   
}
