﻿using Airline.Models;
using ClassLib.Data;
using ClassLib.Interface;
using ClassLib.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Controllers
{
    public class AdminController : Controller
    {
        private FlightContainer flightContainer;

        public AdminController()
        {
            flightContainer = new FlightContainer(new FlightDalMsSql());
        }

        // GET: Admin
        public IActionResult Flight()
        {
            FlightDetailViewModel flightDetailView = new FlightDetailViewModel();
            flightDetailView.Flights = new List<FlightViewModel>();

            FlightContainer flightContainer = new FlightContainer(new FlightDalMsSql());
            List<Flight> flights = flightContainer.getAll();

            foreach (Flight flight in flights)
            {
                flightDetailView.Flights.Add(new FlightViewModel(flight));
            }

            return View(flightDetailView);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int Id)
        {
            Flight flight = flightContainer.getById(Id);
            return View(new FlightViewModel(flight));
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
                    Flight flight = new Flight(new FlightDalMsSql())
                    {
                        aircraftCode = flightViewModel.aircraftCode,
                        aircraftType = flightViewModel.aircraftType,
                        departureCountry = flightViewModel.departureCountry,
                        arrivalCountry = flightViewModel.arrivalCountry,
                        departureDate = flightViewModel.departureDate,
                        arrivalDate = flightViewModel.arrivalDate,
                        flightStatus = flightViewModel.flightStatus
                    };

                    flight.Save();
                    
                    return RedirectToAction("Flight", "Admin");           
                }
                catch
                {
                    return View("Create", "Admin");
                }               
            }
            return View();
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int Id)
        {           
            Flight flight = flightContainer.getById(Id);
            return View(new FlightViewModel(flight));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, FlightViewModel flightViewModel)
        {          
            if (ModelState.IsValid)
            {
                try
                {
                    Flight flight = new Flight(new FlightDalMsSql())
                    {
                        flightId = Id,
                        aircraftCode = flightViewModel.aircraftCode,
                        aircraftType = flightViewModel.aircraftType,
                        departureCountry = flightViewModel.departureCountry,
                        arrivalCountry = flightViewModel.arrivalCountry,
                        departureDate = flightViewModel.departureDate,
                        arrivalDate = flightViewModel.arrivalDate,
                        flightStatus = flightViewModel.flightStatus
                    };

                    flight.Update();

                    return RedirectToAction("Flight", "Admin");
                }
                catch
                {
                    return View("Edit", "Admin");
                }
            }
            return View();
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

                return RedirectToAction("Flight", "Admin");
            }
            catch
            {
                return View("Flight", "Admin");
            }

        }
    }
}
