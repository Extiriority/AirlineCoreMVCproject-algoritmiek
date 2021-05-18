﻿using ClassLib.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Logic
{
    public class FlightContainer
    {
        private readonly IFlightFetch flightContainer;

        public FlightContainer(IFlightFetch flightContainer)
        {
            this.flightContainer = flightContainer;
        }
        public List<Flight> getAll()
        {
            List<FlightDto> flightTemp = flightContainer.getAll();
            List<Flight> flights = new List<Flight>();

            foreach (FlightDto flightDto in flightTemp)
            {
                flights.Add(new Flight(flightDto));
            }
            return flights;
        }

        public FlightDto getById(int id)
        {
            FlightDto flight = flightContainer.getById(id);

            return flight;
        }
    }
}