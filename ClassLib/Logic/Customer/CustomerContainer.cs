using ClassLib.Data;
using ClassLib.Interface;

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
        public bool verifyLogin(string email, string password) => customerContainer.verifyLogin(email, password);
    }
}
