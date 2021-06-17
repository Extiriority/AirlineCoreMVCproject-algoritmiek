using Airline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

using Microsoft.AspNetCore.Http;
using ClassLib.Logic;
using ClassLib.Interface;
using System.Collections.Generic;
using ClassLib.Data;

namespace Airline.Controllers
{
    public class HomeController : Controller
    {
        private readonly TicketContainer ticketContainer;
        private readonly BillingContainer billingContainer;

        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            ticketContainer = new TicketContainer(new TicketDalMsSql());
            billingContainer = new BillingContainer(new BillingDalMsSql());
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

            BillingDetailViewModel billingDetailView = new BillingDetailViewModel();
            billingDetailView.billings = new List<BillingViewModel>();
            IEnumerable<Billing> billings = billingContainer.getAllBillingsById(loggedInCustomer.customerId);

            foreach (Billing billing in billings)
            {
                billingDetailView.billings.Add(new BillingViewModel(billing));
            }

            return string.IsNullOrEmpty(loggedInCustomer.firstName) ? (IActionResult)RedirectToAction("Index", "Home") : View(billingDetailView);            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
