using Airline.Models;
using ClassLib.Data;
using ClassLib.Interface;
using ClassLib.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Airline.Controllers
{
    public class AccountController : Controller
    {
        private readonly Customer customer;
        private readonly CustomerContainer customerContainer;

        public AccountController()
        {
            customer = new Customer(new CustomerDalMsSql());
            customerContainer = new CustomerContainer(new CustomerDalMsSql());
        }

        [HttpPost]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.logoutCustomer();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Login(CustomerLoginViewModel customer)
        {          
            if (ModelState.IsValid)
            {
                try
                {
                    Customer validCustomer = customerContainer.verifyLogin(customer.email, customer.password);
                    
                    logInCustomer(validCustomer);
                    return RedirectToAction("Dashboard", "Home");
                }
                catch 
                {
                    return RedirectToAction("Index", "Home");
                }                        
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: AccountController/Create
        public ActionResult Register()  
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CustomerDto customerDto = new CustomerDto
                    {
                        firstName = customerViewModel.firstName,
                        lastName = customerViewModel.lastName,
                        email = customerViewModel.email,
                        phoneNumber = customerViewModel.phoneNumber,
                        dateOfBirth = customerViewModel.dateOfBirth,
                        gender = customerViewModel.gender,
                        password = new PasswordHash().passwordHash256(customerViewModel.password),
                        isAdmin = false
                    };

                    customer.saveCustomer(new Customer(customerDto));

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error in Encode: {ex.Message}");
                }
            
            }
            return View();
        }


        public ActionResult Update()
        {
            Customer validCustomer = HttpContext.Session.getCustomer();
            Customer customer = customerContainer.getCustomerById(validCustomer.customerId);
            return View(new CustomerViewModel(customer));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Customer validCustomer = HttpContext.Session.getCustomer();
                    CustomerDto customerDto = new CustomerDto
                    {
                        customerId = validCustomer.customerId,
                        firstName = customerViewModel.firstName,
                        lastName = customerViewModel.lastName,
                        email = customerViewModel.email,
                        phoneNumber = customerViewModel.phoneNumber,
                        dateOfBirth = customerViewModel.dateOfBirth,
                        gender = customerViewModel.gender,
                        password = new PasswordHash().passwordHash256(customerViewModel.password)
                    };
                    customer.updateCustomer(new Customer(customerDto));

                    return RedirectToAction("Logout");
                }
                catch
                {
                    return View("Update");
                }
            }
            return RedirectToAction("Update");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                customer.deleteCustomer(id);

                return RedirectToAction("Customer", "Admin");
            }
            catch
            {
                return RedirectToAction("Customer", "Admin");
            }

        }

        private void logInCustomer(Customer validCustomer)
        {
            HttpContext.Session.updateCustomer(validCustomer);
        }

        private Customer updateCustomerInfo(CustomerDto customer)
        {
            Customer validCustomer = HttpContext.Session.getCustomer();
            HttpContext.Session.updateCustomer(validCustomer);
            return validCustomer;
        }
    }
}
