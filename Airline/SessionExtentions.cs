using ClassLib.Interface;
using ClassLib.Logic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline
{
    public static class SessionExtentions
    {
        public static void updateCustomer(this ISession session, Customer customer)
        {
            session.SetInt32("id", customer.customerId);
            session.SetString("firstName", customer.firstName);
            session.SetString("admin", customer.isAdmin.ToString().ToLower());
            setObject(session, "validCustomer", customer);
        }

        public static void setObject(this ISession session, string key, object value)
        {
            if (containsObject(session, key))
            {
                deleteObject(session, key);
            }
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static bool containsObject(this ISession session, string key)
        {
            return session.Get(key) != null;
        }
        public static void deleteObject(this ISession session, string key)
        {
            session.Remove(key);
        }
        public static void logoutCustomer(this ISession session)
        {
            if (containsObject(session, "validCustomer"))
            {
                session.SetInt32("id", 0);
                session.SetString("firstName", string.Empty);
                session.SetString("admin", "false");
                deleteObject(session, "validCustomer");
            }
            createCustomer(session);
        }
        public static void createCustomer(this ISession session)
        {
            if (!containsObject(session, "validCustomer"))
            {
                CustomerDto tempCustomer = new CustomerDto
                {
                    firstName = "",
                    isAdmin = false,
                };
                setObject(session, "validCustomer", tempCustomer);
            }
        }
        public static CustomerDto getCustomer(this ISession session)
        {
            CustomerDto tempCustomer = new CustomerDto();
            if (!string.IsNullOrEmpty(session.GetString("firstName")))
            {
                tempCustomer.customerId = (int)session.GetInt32("id");
                tempCustomer.firstName = session.GetString("firstName");
                tempCustomer.lastName = session.GetString("lastName");
                tempCustomer.email = session.GetString("email");
                tempCustomer.phoneNumber = session.GetString("phoneNumber");
                tempCustomer.gender = session.GetString("gender");
            }
            else
            {
                tempCustomer.firstName = "";
            }
            return getObject(session, "validCustomer", tempCustomer);
        }
        public static CustomerDto getObject(this ISession session, string key, CustomerDto data)
        {            
            return data;
        }
    }
}
