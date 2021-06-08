using ClassLib.Data;
using ClassLib.Interface;
using System.Collections.Generic;
using System.Linq;

namespace ClassLib.Logic
{
    public class CustomerContainer
    {
        private readonly IFetchDal<CustomerDto> customerContainer;

        public CustomerContainer(IFetchDal<CustomerDto> customerContainer)
        {
            this.customerContainer = customerContainer;
        }
        public Customer getCustomerById(int id) => new Customer(customerContainer.getById(id));
        public Customer verifyLogin(string email, string password) => new Customer(customerContainer.verifyLogin(email, new PasswordHash().passwordHash256(password)));
        public IEnumerable<Customer> getAllCustomers() => customerContainer.getAll().Select(customerDto => new Customer(customerDto));

    }
}
