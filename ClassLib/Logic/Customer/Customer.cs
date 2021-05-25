﻿using ClassLib.Interface;
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
        }

        public Customer(ICustomerPersist customer)
        {
            this.customer = customer;
        }

        public void Save()
        {
            CustomerDto data = new CustomerDto
            {
                customerId = this.customerId,
                firstName = this.firstName,
                lastName = this.lastName,
                email = this.email,
                phoneNumber = this.phoneNumber,
                dateOfBirth = this.dateOfBirth,
                gender = this.gender,
                password = this.password
            };
            customer.save(data);
        }

        public void Update()
        {
            CustomerDto data = new CustomerDto
            {
                customerId = this.customerId,
                firstName = this.firstName,
                lastName = this.lastName,
                email = this.email,
                phoneNumber = this.phoneNumber,
                dateOfBirth = this.dateOfBirth,
                gender = this.gender,
                password = this.password
            };
            customer.update(data);
        }
        public void Delete(int id)
        {
            customer.delete(id);
        }

        public void compareLogin()
        {
            CustomerDto data = new CustomerDto
            {
                email = this.email,
                password = this.password
            };
            customer.compareLogin(data);
        }
    }
}
