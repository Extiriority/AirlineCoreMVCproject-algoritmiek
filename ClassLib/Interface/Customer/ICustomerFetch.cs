using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Interface.Customer
{
    public interface ICustomerFetch
    {
        CustomerDto getById(int id);

        bool verifyLogin(string email, string password);
    }
}
