using Airline.Models;
using ClassLib.Data;
using ClassLib.Interface;
using ClassLib.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace Airline.Controllers
{
    public class AdminController : Controller
    {
        private readonly FlightContainer flightContainer;

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
            IEnumerable<Flight> flights = flightContainer.getAllFlights();

            foreach (Flight flight in flights)
            {
                flightDetailView.Flights.Add(new FlightViewModel(flight));
            }

            return View(flightDetailView);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int Id)
        {
            Flight flight = flightContainer.getFlightById(Id);
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
                    Flight flight = new Flight(new FlightDalMsSql());
                    FlightDto flightDto = new FlightDto
                    {
                        aircraftCode = flightViewModel.aircraftCode,
                        aircraftType = flightViewModel.aircraftType,
                        departureCountry = flightViewModel.departureCountry,
                        arrivalCountry = flightViewModel.arrivalCountry,
                        departureDate = flightViewModel.departureDate,
                        arrivalDate = flightViewModel.arrivalDate,
                        flightStatus = flightViewModel.flightStatus,
                        price = flightViewModel.price
                    };
                    flight.saveFlight(new Flight(flightDto));
                    
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
            Flight flight = flightContainer.getFlightById(Id);
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
                    Flight flight = new Flight(new FlightDalMsSql());
                    FlightDto flightDto = new FlightDto
                    {
                        flightId = Id,
                        aircraftCode = flightViewModel.aircraftCode,
                        aircraftType = flightViewModel.aircraftType,
                        departureCountry = flightViewModel.departureCountry,
                        arrivalCountry = flightViewModel.arrivalCountry,
                        departureDate = flightViewModel.departureDate,
                        arrivalDate = flightViewModel.arrivalDate,
                        flightStatus = flightViewModel.flightStatus,
                        price = flightViewModel.price
                    };

                    flight.updateFlight(new Flight(flightDto));

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
        public ActionResult Delete(int id)
        {
            try
            {
                Flight flight = new Flight(new FlightDalMsSql());

                flight.DeleteFlight(id);

                return RedirectToAction("Flight", "Admin");
            }
            catch
            {
                return View("Flight", "Admin");
            }

        }
    }
}
