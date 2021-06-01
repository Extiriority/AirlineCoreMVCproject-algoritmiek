using Airline.Models;
using ClassLib.Data.Customer;
using ClassLib.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Scrypt;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.AspNetCore.Session;
using System.Security;
using Microsoft.AspNetCore.Http;

namespace Airline.Controllers
{
    public class AccountController : Controller
    {


        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Login(CustomerLoginViewModel customerLoginViewModel)
        {
            
            string connectionString = "Data Source=mssql.fhict.local;Initial Catalog=dbi463189_airline;Persist Security Info=True;User ID=dbi463189_airline;Password=m4VEw2tX;";
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT Email,Password FROM Customer " +
                               "WHERE Email = @email" +
                               "Password = @password";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Email", customerLoginViewModel.email);
            cmd.Parameters.AddWithValue("@Password", customerLoginViewModel.password);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                
                
            }
            return RedirectToAction("Index", "Home");
            /*try
             {
                 ScryptEncoder encoder = new ScryptEncoder();
                 
                 Customer validCustomer = new Customer(new CustomerDalMsSql())
                 {
                     email = customerLoginViewModel.email,
                     password = encoder.Encode(customerLoginViewModel.password)
                 };

                 validCustomer.compareLogin();

                 if (validCustomer == null)
                 {
                     ViewBag.Error = "Username or password is invalid.";
                     return View();
                 }

                 bool isValidCustomer = encoder.Compare(customerLoginViewModel.password, validCustomer.password);
                 if (isValidCustomer)
                 {
                     return View("User");
                 }
                 else
                 { 
                     ViewBag.Error = "Username or password is invalid.";
                 }

                 return RedirectToAction("Index", "Home");
             }
             catch (Exception ex)
             {
                 throw new Exception($"Error in Encode: {ex.Message}");
             }       */
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
                    Customer customer = new Customer(new CustomerDalMsSql())
                    {
                        firstName = customerViewModel.firstName,
                        lastName = customerViewModel.lastName,
                        email = customerViewModel.email,
                        phoneNumber = customerViewModel.phoneNumber,
                        dateOfBirth = customerViewModel.dateOfBirth,
                        gender = customerViewModel.gender,
                        password = encoder.Encode(customerViewModel.confirmPassword)
                    };

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
    }
}
