﻿using Airline.Models;
using ClassLib.Data;
using ClassLib.Interface;
using ClassLib.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public IActionResult Flight()
        {
            FlightDetailViewModel flightDetailView = new FlightDetailViewModel();
            flightDetailView.Flights = new List<FlightViewModel>();

            FlightContainer flightContainer = new FlightContainer(new FlightDalMsSql());
            List<Flight> flights = flightContainer.GetAllFlights();

            foreach (Flight flight in flights)
            {
                flightDetailView.Flights.Add(new FlightViewModel(flight));
            }

            return View(flightDetailView);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int Id)
        { 
            FlightContainer flightContainer = new FlightContainer(new FlightDalMsSql());
            FlightDto flight = flightContainer.FlightGetById(Id);

            return View(flight);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FlightViewModel flightViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Flight flight = new Flight(new FlightDalMsSql());
                    flight.aircraftType = flightViewModel.aircraftType;
                    flight.departureCountry = flightViewModel.departureCountry;
                    flight.arrivalCountry = flightViewModel.arrivalCountry;
                    flight.departureDate = flightViewModel.departureDate;
                    flight.arrivalDate = flightViewModel.arrivalDate;
                    flight.flightStatus = flightViewModel.flightStatus;

                    if (flight.Create())
                    {
                        return RedirectToAction("Flight", "Admin");
                    }
                }
                catch
                {
                    return View("Create", "Admin");
                }               
            }
            return View();
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
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


        // POST: Admin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FlightViewModel flightViewModel)
        {
            try
            {
                Flight flight = new Flight(new FlightDalMsSql());

                flight.Delete(id);

                FlightDetailViewModel flightDetailView = new FlightDetailViewModel();
                flightDetailView.Flights = new List<FlightViewModel>();

                FlightContainer flightContainer = new FlightContainer(new FlightDalMsSql());
                List<Flight> newFlightList = flightContainer.GetAllFlights();

                foreach (Flight flights in newFlightList)
                {
                    flightDetailView.Flights.Add(new FlightViewModel(flights));
                }

                return View("Flight", flightDetailView);
            }
            catch
            {
                return View("Flight", "Admin");
            }

        }
    }
}
