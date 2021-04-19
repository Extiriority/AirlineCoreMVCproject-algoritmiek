using ClassLib.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Logic
{
    public class FlightContainer
    {
        private IFlightContainer flightContainer;

        public FlightContainer(IFlightContainer flightContainer)
        {
            this.flightContainer = flightContainer;
        }
        public List<Flight> GetAllFlights()
        {
            List<FlightDTO> flightTemp = flightContainer.GetAllFlights();
            List<Flight> flights = new List<Flight>();

            foreach (FlightDTO flightDTO in flightTemp)
            {
                flights.Add(new Flight(flightDTO));
            }
            return flights;
        }
    }
}
