using Airline.Models;
using ClassLib.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassLib.Data;
using System.Collections.Generic;
using ClassLib.Interface;
using System;

namespace Airline.Controllers
{
    public class TicketController : Controller
    {
        private readonly TicketContainer ticketContainer;
        private readonly Ticket ticket;
        private readonly FlightContainer flightContainer;
        private readonly Flight flight;
        private readonly BillingContainer billingContainer;
        private readonly Billing billing;
        public TicketController()
        {
            ticketContainer = new TicketContainer(new TicketDalMsSql());
            ticket = new Ticket(new TicketDalMsSql());
            flightContainer = new FlightContainer(new FlightDalMsSql());
            flight = new Flight(new FlightDalMsSql());
            billingContainer = new BillingContainer(new BillingDalMsSql());
            billing = new Billing(new BillingDalMsSql());
        }

        public IActionResult Search()
        {
            Customer loggedInCustomer = HttpContext.Session.getCustomer();
            
            FlightDetailViewModel flightDetailView = new FlightDetailViewModel();
            flightDetailView.Flights = new List<FlightViewModel>();
            IEnumerable<Flight> flights = flightContainer.getAllFlights();

            foreach (Flight flight in flights)
            {
                flightDetailView.Flights.Add(new FlightViewModel(flight));
            }
            return string.IsNullOrEmpty(loggedInCustomer.firstName) ? (IActionResult)RedirectToAction("Index", "Home") : View(flightDetailView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string searchString)
        {
            Customer loggedInCustomer = HttpContext.Session.getCustomer();

            FlightDetailViewModel flightDetailView = new FlightDetailViewModel();
            flightDetailView.Flights = new List<FlightViewModel>();
            IEnumerable<Flight> flights = flightContainer.searchFlight(searchString);

            foreach (Flight flight in flights)
            {
                flightDetailView.Flights.Add(new FlightViewModel(flight));
            }
            return string.IsNullOrEmpty(loggedInCustomer.firstName) ? (ActionResult)RedirectToAction("Index", "Home") : View(flightDetailView);
        }

        public IActionResult Create()
        {
            Customer loggedInCustomer = HttpContext.Session.getCustomer();
            return string.IsNullOrEmpty(loggedInCustomer.firstName) ? (IActionResult)RedirectToAction("Register", "Account") : View();           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TicketViewModel ticketViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Customer loggedInCustomer = HttpContext.Session.getCustomer();
                    TicketDto ticketDto = new TicketDto
                    {
                        customerId = loggedInCustomer.customerId,
                        travelType = ticketViewModel.travelType,
                        classType = ticketViewModel.classType,
                        numberOfAdults = ticketViewModel.numberOfAdults,
                        numberOfChildren = ticketViewModel.numberOfChildren
                    };
                    int ticketId = ticket.saveTicketAndRetrieveId(new Ticket(ticketDto));

                    HttpContext.Session.SetString("ticketId", ticketId.ToString());
                    return RedirectToAction("Search"); 
                }
                catch
                {
                    return View("Index", "Home");
                }
            }
            return View();
        }


        public ActionResult Book(int id)
        {
            try
            {
                updateTicket(id);
                Customer loggedInCustomer = HttpContext.Session.getCustomer();
                Flight flight = flightContainer.getFlightById(id);
                int ticketId = Convert.ToInt32(HttpContext.Session.GetString("ticketId"));
                Ticket ticket = ticketContainer.getTicketById(ticketId);
                CreateBilling(flight, ticket, loggedInCustomer);
                const int firstClassRate = 3;
                const double childrensRate = 0.75;
                double adultPrice;
                double childPrice;
                double totalPrice;
                if (ticket.classType == "First Class")
                {
                    adultPrice = flight.price * firstClassRate;
                    childPrice = flight.price * childrensRate * firstClassRate;
                    totalPrice = ticket.numberOfAdults * (flight.price * firstClassRate) + ticket.numberOfChildren * (flight.price * childrensRate * firstClassRate);
                }
                else
                {
                    adultPrice = flight.price;
                    childPrice = flight.price * childrensRate;
                    totalPrice = ticket.numberOfAdults * flight.price + ticket.numberOfChildren * (flight.price * childrensRate);
                }

                ViewBag.Customer = loggedInCustomer;
                ViewBag.Flight = flight;
                ViewBag.Ticket = ticket;
                ViewBag.AdultFarePrice = adultPrice;
                ViewBag.ChildFarePrice = childPrice;
                ViewBag.TotalPrice = totalPrice;
                return string.IsNullOrEmpty(loggedInCustomer.firstName) ? (ActionResult)RedirectToAction("Index", "Home") : View();
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
        private void CreateBilling(Flight flight, Ticket ticket, Customer customer)
        {
            const int firstClassRate = 3;
            const double childrensRate = 0.75;
            double totalPrice;
            if (ticket.classType == "First Class")
            {
                totalPrice = ticket.numberOfAdults * (flight.price * firstClassRate) + ticket.numberOfChildren * (flight.price * childrensRate * firstClassRate);
            }
            else
            {
                totalPrice = ticket.numberOfAdults * flight.price + ticket.numberOfChildren * (flight.price * childrensRate);
            }
            BillingDto billingDto = new BillingDto
            {
                flightId = flight.flightId,
                customerId = customer.customerId,
                ticketId = ticket.ticketId,
                grandTotal = totalPrice,
                paymentDate = DateTime.Now,
                paymentStatus = true
            };
            billing.saveBilling(new Billing(billingDto));
        }

        private void updateTicket(int id)
        {
            int ticketId = Convert.ToInt32(HttpContext.Session.GetString("ticketId"));
            var ticketdata = ticketContainer.getTicketById(ticketId);
            TicketDto ticketDto = new TicketDto
            {
                ticketId = ticketdata.ticketId,
                flightId = id,
                customerId = ticketdata.customerId,
                travelType = ticketdata.travelType,
                classType = ticketdata.classType,
                numberOfAdults = ticketdata.numberOfAdults,
                numberOfChildren = ticketdata.numberOfChildren
            };
            ticket.updateTicket(new Ticket(ticketDto));
        }


        // POST: TicketController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                billing.deleteBilling(id);
                return RedirectToAction("Dashboard", "Home");
            }
            catch
            {
                return RedirectToAction("Dashboard", "Home");
            }
        }
    }
}
