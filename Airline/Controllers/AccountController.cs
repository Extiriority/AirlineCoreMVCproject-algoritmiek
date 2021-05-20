using Airline.Models;
using ClassLib.Data.Customer;
using ClassLib.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Scrypt;
using ClassLib.Interface;

namespace Airline.Controllers
{
    public class AccountController : Controller
    {
        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                    ScryptEncoder encoder = new ScryptEncoder();                                     
                    Customer customer = new Customer(new CustomerDalMsSql());
                    customer.firstName      = customerViewModel.firstName;
                    customer.lastName       = customerViewModel.lastName;
                    customer.email          = customerViewModel.email;
                    customer.phoneNumber    = customerViewModel.phoneNumber;
                    customer.dateOfBirth    = customerViewModel.dateOfBirth;
                    customer.gender         = customerViewModel.gender;
                    customer.password       = encoder.Encode(customerViewModel.confirmPassword);
                    
                    customer.Save();

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error in Encode: {ex.Message}");
                }
            
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CustomerContainer customerContainer = new CustomerContainer(new CustomerDalMsSql());
                    //CustomerDto flightDetail = customerContainer.getById(Id);
                    ScryptEncoder encoder = new ScryptEncoder();
                    //bool validCustomer = encoder.Compare(customerViewModel.password, );
                    
                    //hier gebleven!!!!!!!!!!!!!!!!!!!!!!!!!
                    //customer.Save();

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error in Encode: {ex.Message}");
                }

            }
            return View();
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
