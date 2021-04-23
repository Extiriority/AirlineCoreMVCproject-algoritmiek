using ClassLib.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Data
{
    public class FlightDALStub 
    {
        public List<FlightDto> getAllFlights()
        {
            List<FlightDto> flights = new List<FlightDto>();
            FlightDto flight1 = new FlightDto();
            flight1.flightId = 1;
            flight1.aircraftType = "Airbus A320";
            flight1.departureCountry = "Netherlands";
            flight1.arrivalCountry = "Japan";
            flight1.departureDate = new DateTime(2008, 5, 1, 8, 30, 00);
            flight1.arrivalDate = new DateTime(2008, 5, 1, 19, 45, 00);
            flight1.flightStatus = true;
            
            flights.Add(flight1);

            FlightDto flight2 = new FlightDto();
            flight2.flightId = 2;
            flight2.aircraftType = "Boeing 747";
            flight2.departureCountry = "Netherlands";
            flight2.arrivalCountry = "Vietnam";
            flight2.departureDate = new DateTime(2008, 5, 3, 6, 30, 00);
            flight2.arrivalDate = new DateTime(2008, 5, 3, 16, 40, 00);
            flight2.flightStatus = true;

            flights.Add(flight2);

            FlightDto flight3 = new FlightDto();
            flight3.flightId = 3;
            flight3.aircraftType = "Airbus A321";
            flight3.departureCountry = "Netherlands";
            flight3.arrivalCountry = "Italy";
            flight2.departureDate = new DateTime(2008, 7, 18, 7, 30, 00);
            flight2.arrivalDate = new DateTime(2008, 7, 18, 9, 05, 00);
            flight3.flightStatus = false;

            flights.Add(flight3);

            return flights;
        }
    }
}
