using ClassLib.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Logic
{
    public class Flight
    {
        public string Destination { get; set; }
        public string AircraftType { get; set; }
        public bool FlightStatus { get; set; }

        public Flight(FlightDTO flightDTO)
        {
            this.Destination = flightDTO.Destination;
            this.AircraftType = flightDTO.AircraftType;
            this.FlightStatus = flightDTO.FlightStatus;
        }
    }
}
