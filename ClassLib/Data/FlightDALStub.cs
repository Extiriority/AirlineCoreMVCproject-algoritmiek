using ClassLib.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Data
{
    public class FlightDALStub : IFlightContainer
    {
        public List<FlightDTO> GetAllFlights()
        {
            List<FlightDTO> flights = new List<FlightDTO>();
            FlightDTO flight1 = new FlightDTO();
            flight1.Destination = "Japan";
            flight1.AircraftType = "Airbus A320";
            flight1.FlightStatus = true;

            flights.Add(flight1);

            FlightDTO flight2 = new FlightDTO();
            flight2.Destination = "Vietnam";
            flight2.AircraftType = "Boeing 747";
            flight2.FlightStatus = true;

            flights.Add(flight2);

            FlightDTO flight3 = new FlightDTO();
            flight2.Destination = "Italy";
            flight2.AircraftType = "Airbus A321";
            flight2.FlightStatus = true;

            flights.Add(flight3);

            return flights;
        }
    }
}
