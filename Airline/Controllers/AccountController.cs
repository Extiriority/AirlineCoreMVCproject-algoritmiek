/*using Airline.Models;
using ClassLib.Data.Customer;
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
            HttpContext.Session.Remove("email");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Login(CustomerLoginViewModel customerLoginViewModel)
        {
            
            if (ModelState.IsValid)
            {
                CustomerContainer customer = new CustomerContainer(new CustomerDalMsSql());
                bool userId = customer.verifyLogin(customerLoginViewModel.email, customerLoginViewModel.password);

                if (userId == false)
                {
                    return RedirectToAction("Index", "Home");
                }
                HttpContext.Session.SetString("email", customerLoginViewModel.email);
                return RedirectToAction("Dashboard", "Home");
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
                        password = customerViewModel.confirmPassword
                    };

                    customer.save(new Customer(customerDto));

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error in Encode: {ex.Message}");
                }
            
            }
            return View();
        }
    }
}
*/