using Airline.Models;
using ClassLib.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassLib.Data;
using System.Collections.Generic;
using ClassLib.Interface;

namespace Airline.Controllers
{
    public class TicketController : Controller
    {

        // GET: TicketController
        public ActionResult Index()
        {
            return View();
        }

        // GET:
        public IActionResult Search()
        {
            FlightDetailViewModel flightDetailView = new FlightDetailViewModel();
            flightDetailView.Flights = new List<FlightViewModel>();

            FlightContainer flightContainer = new FlightContainer(new FlightDalMsSql());
            IEnumerable<Flight> flights = flightContainer.getAllFlights();

            foreach (Flight flight in flights)
            {
                flightDetailView.Flights.Add(new FlightViewModel(flight));
            }
            return View(flightDetailView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(int id, string searchString)
        {
            FlightDetailViewModel flightDetailView = new FlightDetailViewModel();
            flightDetailView.Flights = new List<FlightViewModel>();

            FlightContainer flightContainer = new FlightContainer(new FlightDalMsSql());
            IEnumerable<Flight> flights = flightContainer.searchFlight(searchString);

            foreach (Flight flight in flights)
            {
                flightDetailView.Flights.Add(new FlightViewModel(flight));
            }
            return View(flightDetailView);
        }

        // GET: TicketController/Create
        public IActionResult Create()
        {
            Customer loggedInUser = HttpContext.Session.getCustomer();
            return string.IsNullOrEmpty(loggedInUser.firstName) ? (IActionResult)RedirectToAction("Index", "Home") : View();           
        }
        // POST: TicketController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TicketViewModel ticketViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Ticket ticket = new Ticket(new TicketDalMsSql());
                    TicketDto ticketDto = new TicketDto
                    {
                        ticketId = ticketViewModel.ticketId,
                        travelType = ticketViewModel.travelType,
                        classType = ticketViewModel.classType,
                        numberOfPassengers = ticketViewModel.numberOfPassenger
                    };
                    ticket.saveTicket(new Ticket(ticketDto));

                    return RedirectToAction("Confirm"); 
                }
                catch
                {
                    return View("Index", "Home");
                }
            }
            return View();
        }

        public ActionResult Confirm()
        {
            TicketDetailViewModel ticketDetailView = new TicketDetailViewModel();
            ticketDetailView.Tickets = new List<TicketViewModel>();

            TicketContainer ticketContainer = new TicketContainer(new TicketDalMsSql());
            IEnumerable<Ticket> tickets = ticketContainer.getAllTickets();

            foreach (Ticket ticket in tickets)
            {
                ticketDetailView.Tickets.Add(new TicketViewModel(ticket));
            }
            return View(ticketDetailView);
        }

        // POST: TicketController/Edit/5

        public ActionResult Book(int id, TicketViewModel ticketViewModel)
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



        // POST: TicketController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Ticket ticket = new Ticket(new TicketDalMsSql());
                ticket.deleteTicket(id);
                return RedirectToAction("Confirm", "Ticket");
            }
            catch
            {
                return View();
            }
        }
    }
}
