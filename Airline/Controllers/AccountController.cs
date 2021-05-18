using Airline.Models;
using ClassLib.Data.Customer;
using ClassLib.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public ActionResult Create(CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Customer customer = new Customer(new CustomerDalMsSql());
                    customer.firstName      = customerViewModel.firstName;
                    customer.lastName       = customerViewModel.lastName;
                    customer.email          = customerViewModel.email;
                    customer.phoneNumber    = customerViewModel.phoneNumber;
                    customer.dateOfBirth    = customerViewModel.dateOfBirth;
                    customer.gender         = customerViewModel.gender;
                    customer.username       = customerViewModel.username;
                    customer.password       = customerViewModel.password;

                    customer.Save();

                    return RedirectToAction("Index", "Home");
                }
                catch
                {
                    return RedirectToAction("Register", "Account");
                }
            }
            return RedirectToAction();
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
