using Airline.Models;
using ClassLib.Data;
using ClassLib.Interface;
using ClassLib.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Airline.UnitTests
{
    [TestClass]
    public class FlighTests
    {


        [TestMethod]
        public void getAll_MockFlights_AreEqual()
        {
            // Arrange
            FlightContainer flightContainer = new FlightContainer(new FlightDALStub());

            // Act
            List<Flight> flights = flightContainer.getAll();

            // Assert
            Assert.AreEqual(3, flights.Count, "Not all flights are present.");
        }

        [TestMethod]
        public void save_MockFlights_AreEqual()
        {
            // Arrange
            FlightDALStub flightDALStub = new FlightDALStub();
            FlightContainer flightContainer = new FlightContainer(flightDALStub);
            Flight flightTest1 = new Flight(new FlightDto() { flightId = 4, aircraftCode = "FD444", aircraftType = "777X", departureCountry = "Netherlands", arrivalCountry = "Australia", departureDate = new DateTime(2009, 5, 3, 14, 30, 00), arrivalDate = new DateTime(2009, 5, 4, 1, 45, 00), flightStatus = true });
            Flight flightTest2 = new Flight(new FlightDto() { flightId = 5, aircraftCode = "FD879", aircraftType = "A340", departureCountry = "Netherlands", arrivalCountry = "Brazil", departureDate = new DateTime(2009, 5, 3, 14, 30, 00), arrivalDate = new DateTime(2009, 5, 3, 20, 45, 00), flightStatus = true });


            Flight flight1 = new Flight(flightDALStub)
            {
                flightId = flightTest1.flightId,
                aircraftCode = flightTest1.aircraftCode,
                aircraftType = flightTest1.aircraftType,
                departureCountry = flightTest1.departureCountry,
                arrivalCountry = flightTest1.arrivalCountry,
                departureDate = flightTest1.departureDate,
                arrivalDate = flightTest1.arrivalDate,
                flightStatus = flightTest1.flightStatus
            };

            Flight flight2 = new Flight(flightDALStub)
            {
                flightId = flightTest2.flightId,
                aircraftCode = flightTest2.aircraftCode,
                aircraftType = flightTest2.aircraftType,
                departureCountry = flightTest2.departureCountry,
                arrivalCountry = flightTest2.arrivalCountry,
                departureDate = flightTest2.departureDate,
                arrivalDate = flightTest2.arrivalDate,
                flightStatus = flightTest2.flightStatus
            };
            
            // Act
            flight1.Save();
            flight2.Save();
            List<Flight> flights = flightContainer.getAll();

            // Assert
            Assert.AreEqual(5, flights.Count, "Not all flights are present.");
            Assert.AreEqual("FD444", flights[3].aircraftCode, "The codename and index is not equal.");
            Assert.AreEqual("Brazil", flights[4].arrivalCountry, "The arrival country and index is not equal.");
         
            //loop all parameters check
        }

        [TestMethod]
        public void getById_MockFlights_AreEqual()
        {
            // Arrange
            FlightContainer flightContainer = new FlightContainer(new FlightDALStub());

            // Act
            FlightDto flight = flightContainer.getById(1);

            // Assert
            Assert.AreEqual("Japan", flight.arrivalCountry, "The arrival country and flight id is not equal.");
            
        }

        [TestMethod]
        public void update_MockFlights_AreEqual()
        {
            

        }

        [TestMethod]
        public void delete_MockFlights_AreEqual()
        {
            // Arrange
            FlightDALStub flightDALStub = new FlightDALStub();
            FlightContainer flightContainer = new FlightContainer(flightDALStub);
            Flight flight = new Flight(flightDALStub);

            // Act
            flight.Delete(1);
            List<Flight> flights = flightContainer.getAll();

            // Assert
            Assert.AreEqual(2, flights.Count);
            Assert.AreEqual("A321", flights[1].aircraftType);
        }
    }
}
