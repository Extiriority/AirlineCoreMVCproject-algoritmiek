using Airline.Models;
using ClassLib.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using ClassLib.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            IEnumerable<Flight> flights = flightContainer.getAll();

            foreach (Flight flight in flights)
            {
                flightDetailView.Flights.Add(new FlightViewModel(flight));
            }
            return View(flightDetailView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string searchString)
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
        public ActionResult Create()
        {
            return View();
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
                        numberOfPassengers = ticketViewModel.numberOfpassenger
                    };
                    ticket.save(new Ticket(ticketDto));

                    return RedirectToAction("Search");
                }
                catch
                {
                    return View("Index", "Home");
                }
            }
            return View();
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
