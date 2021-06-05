using ClassLib.Interface;
using ClassLib.Interface.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Logic
{
    public class CustomerContainer
    {
        private readonly ICustomerFetch customerContainer;

        public CustomerContainer(ICustomerFetch customerContainer)
        {
            this.customerContainer = customerContainer;
        }
        public Customer getById(int id) => new Customer(customerContainer.getById(id));
        public bool verifyLogin(string email, string password) => customerContainer.verifyLogin(email, password);
    }
}
