﻿using Airline.Models;
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
        public TicketController()
        {
            ticketContainer = new TicketContainer(new TicketDalMsSql());
            ticket = new Ticket(new TicketDalMsSql());
            flightContainer = new FlightContainer(new FlightDalMsSql());
            flight = new Flight(new FlightDalMsSql());
        }
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
            IEnumerable<Flight> flights = flightContainer.getAllFlights();

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
                    Customer loggedInCustomer = HttpContext.Session.getCustomer();
                    TicketDto ticketDto = new TicketDto
                    {
                        customerId = loggedInCustomer.customerId,
                        travelType = ticketViewModel.travelType,
                        classType = ticketViewModel.classType,
                        numberOfPassengers = ticketViewModel.numberOfPassenger
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

        // POST: TicketController/Book/5

        public ActionResult Book(int id)
        {
            try
            {
                updateFlight(id);
                Customer loggedInCustomer = HttpContext.Session.getCustomer();
                Flight flight = flightContainer.getFlightById(id);
                int ticketId = Convert.ToInt32(HttpContext.Session.GetString("ticketId"));
                Ticket ticket = ticketContainer.getTicketById(ticketId);

                ViewBag.Customer = loggedInCustomer;
                ViewBag.Flight = flight;
                ViewBag.Ticket = ticket;
                return View();
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private void updateFlight(int id)
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
                numberOfPassengers = ticketdata.numberOfPassengers
            };
            ticket.updateTicket(new Ticket(ticketDto));
        }
        private void processOrder()
        {

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
                return RedirectToAction("Dashboard", "Home");
            }
            catch
            {
                return View("Index", "Home");
            }
        }
    }
}
