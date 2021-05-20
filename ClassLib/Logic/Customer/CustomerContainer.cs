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

        public CustomerDto getById(int id)
        {
            CustomerDto customer = customerContainer.getById(id);

            return customer;
        }
    }
}
