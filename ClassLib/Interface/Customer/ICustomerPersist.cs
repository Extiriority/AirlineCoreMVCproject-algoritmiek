using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Interface.Customer
{
    public interface ICustomerPersist
    {
        void save(CustomerDto customer);
        void delete(int Id);
        void update(CustomerDto customer);
        void compareLogin(CustomerDto customer);
    }
}
