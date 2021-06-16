﻿using ClassLib.Interface;
using ClassLib.Logic;
using System;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using Airline.UnitTests.Airline.UnitTests;
using Microsoft.AspNetCore.Http;
using System.Web.Http;

namespace Airline.UnitTests
{
    public class FlighTest
    {

        private readonly Flight validFlight1 = new(new FlightDto()
        {
            flightId = 4,
            aircraftCode = "FD444",
            aircraftType = "777X",
            departureCountry = "Netherlands",
            arrivalCountry = "Australia",
            departureDate = new DateTime(2022, 5, 3, 14, 30, 00),
            arrivalDate = new DateTime(2022, 5, 4, 1, 45, 00),
            flightStatus = true,
            price = 475
        });

        private readonly Flight validFlight2 = new(new FlightDto()
        {
            flightId = 5,
            aircraftCode = "FD879",
            aircraftType = "A340",
            departureCountry = "Netherlands",
            arrivalCountry = "Brazil",
            departureDate = new DateTime(2022, 5, 3, 14, 30, 00),
            arrivalDate = new DateTime(2022, 5, 3, 20, 45, 00),
            flightStatus = true,
            price = 325
        });

        private readonly Flight updateFlight1 = new(new FlightDto()
        {
            flightId = 3,
            aircraftCode = "FD596",
            aircraftType = "A340",
            departureCountry = "Netherlands",
            arrivalCountry = "Italy",
            departureDate = new DateTime(2022, 7, 18, 7, 30, 00),
            arrivalDate = new DateTime(2022, 7, 18, 9, 05, 00),
            flightStatus = false,
            price = 60
        });
        
        private readonly Flight invalidFlight1 = new(new FlightDto()
        {
            flightId = 6,
            aircraftCode = null,
            aircraftType = null,
            departureCountry = "Netherlands",
            arrivalCountry = "Romania",
            departureDate = new DateTime(2008, 7, 18, 7, 30, 00),
            arrivalDate = new DateTime(2008, 7, 18, 9, 05, 00),
            flightStatus = false,
            price = 40
        });


        [Test]
        public void getAll_MockFlights_AreEqual()
        {
            // Arrange
            FlightContainer flightContainer = new(new FlightDALStubs());
            // Act
            var flights = flightContainer.getAllFlights().ToList();
            // Assert
            Assert.AreEqual(3, flights.Count, "Not all flights are present.");
        }

        [Test]
        public void save_MockFlights_AreEqual()
        {
            // Arrange
            FlightDALStubs flightDalStub = new();
            FlightContainer flightContainer = new(flightDalStub);
            Flight flight = new(flightDalStub);

            // Act & Assert
            Assert.DoesNotThrow(() => flight.saveFlight(validFlight1));
            Assert.DoesNotThrow(() => flight.saveFlight(validFlight2));
            Assert.Catch<FlightAddException>(() => flight.saveFlight(invalidFlight1));
            
            var flights = flightContainer.getAllFlights().ToList();
            Assert.AreEqual(5, flights.Count, "Not all flights are present.");
        }

        [Test]
        public void getById_MockFlights_AreEqual()
        {
            // Arrange
            FlightDALStubs flightDalStub = new();
            FlightContainer flightContainer = new(flightDalStub);
            Flight flight = new(flightDalStub);
            int getIdfirst = 1;
            int getIdlast = 5;
            // Act
            flight.saveFlight(validFlight1);
            flight.saveFlight(validFlight2);
            Flight flight1 = flightContainer.getFlightById(getIdfirst);
            Flight flight2 = flightContainer.getFlightById(getIdlast);
            var flights = flightContainer.getAllFlights().ToList();
            // Assert
            Assert.IsNotNull(flight1);
            Assert.AreEqual(flight1!.flightId, flights[0].flightId);
            Assert.AreEqual(flight1!.aircraftCode, flights[0].aircraftCode);
            Assert.AreEqual(flight1!.arrivalCountry, flights[0].arrivalCountry);

            Assert.IsNotNull(flight2);
            Assert.AreEqual(flight2!.flightId, flights[4].flightId);
            Assert.AreEqual(flight2!.aircraftCode, flights[4].aircraftCode);
            Assert.AreEqual(flight2!.arrivalCountry, flights[4].arrivalCountry);
        }

        [Test]
        public void update_MockFlights_AreEqual()
        {
            // Arrange
            FlightDALStubs flightDalStub = new();
            FlightContainer flightContainer = new(flightDalStub);
            Flight flight = new(flightDalStub);

            // Act & Assert
            flight.updateFlight(updateFlight1);
            var flights = flightContainer.getAllFlights().ToList();
            Assert.IsNotNull(updateFlight1);
            Assert.AreEqual(updateFlight1!.flightId, flights[2].flightId);
            Assert.AreEqual(updateFlight1!.aircraftCode, flights[2].aircraftCode);
            Assert.AreEqual(updateFlight1!.arrivalCountry, flights[2].arrivalCountry);
        }

        [Test]
        public void delete_MockFlights_AreEqual()
        {
            // Arrange
            FlightDALStubs flightDALStub = new FlightDALStubs();
            FlightContainer flightContainer = new FlightContainer(flightDALStub);
            Flight flight = new Flight(flightDALStub);
            int idToDelete = 1;

            // Act
            flight.deleteFlight(idToDelete);
            var flights = flightContainer.getAllFlights().ToList();
            // Assert
            Assert.AreEqual(2, flights.Count);
            Assert.AreEqual("A321", flights[1].aircraftType);
        }
    }
}
