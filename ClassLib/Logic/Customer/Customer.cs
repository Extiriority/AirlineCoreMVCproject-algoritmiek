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

        public int customerId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string gender { get; set; }
        public string password { get; set; }

        public Customer(CustomerDto data)
        {
            this.customerId     = data.customerId;
            this.firstName      = data.firstName;
            this.lastName       = data.lastName;
            this.email          = data.email;
            this.phoneNumber    = data.phoneNumber;
            this.dateOfBirth    = data.dateOfBirth;
            this.gender         = data.gender;
            this.password       = data.password;

            customer.save(data);
        }

        public Customer(ICustomerPersist customer)
        {
            this.customer = customer;
        }

        public void Save()
        {
            CustomerDto data = new CustomerDto();
            data.customerId     = this.customerId;
            data.firstName      = this.firstName;
            data.lastName       = this.lastName;
            data.email          = this.email;
            data.phoneNumber    = this.phoneNumber;
            data.dateOfBirth    = this.dateOfBirth;
            data.gender         = this.gender;
            data.password       = this.password;

            customer.save(data);
        }

        public void Update()
        {
            CustomerDto data = new CustomerDto();
            data.customerId     = this.customerId;
            data.firstName      = this.firstName;
            data.lastName       = this.lastName;
            data.email          = this.email;
            data.phoneNumber    = this.phoneNumber;
            data.dateOfBirth    = this.dateOfBirth;
            data.gender         = this.gender;
            data.password       = this.password;

            customer.update(data);
        }
        public void Delete(int id)
        {
            customer.delete(id);
        }
    }
}
