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
                    CustomerContainer customerContainer = new CustomerContainer(new CustomerDalMsSql());
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
                    Customer customer = new Customer(new CustomerDalMsSql());
                    CustomerDto customerDto = new CustomerDto
                    {
                        firstName = customerViewModel.firstName,
                        lastName = customerViewModel.lastName,
                        email = customerViewModel.email,
                        phoneNumber = customerViewModel.phoneNumber,
                        dateOfBirth = customerViewModel.dateOfBirth,
                        gender = customerViewModel.gender,
                        password = new PasswordHash().passwordHash256(customerViewModel.confirmPassword)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Customer customer = new Customer(new CustomerDalMsSql());
                customer.deleteCustomer(id);

                return RedirectToAction("Customer", "Admin");
            }
            catch
            {
                return View("Customer", "Admin");
            }

        }

        private void logInCustomer(Customer validCustomer)
        {
            HttpContext.Session.updateCustomer(validCustomer);
        }
    }
}
