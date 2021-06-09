using Airline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

using Microsoft.AspNetCore.Http;
using ClassLib.Logic;
using ClassLib.Interface;

namespace Airline.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        { 
            return View();
        }

        public IActionResult Privacy()
        {
           
            return View();
        }
        public IActionResult Flight()
        {
            
            return View();
        }

        public IActionResult Dashboard()
        {
            Customer loggedInCustomer = HttpContext.Session.getCustomer();
            ViewBag.User = loggedInCustomer;
            return string.IsNullOrEmpty(loggedInCustomer.firstName) ? (IActionResult)RedirectToAction("Index", "Home") : View();            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
