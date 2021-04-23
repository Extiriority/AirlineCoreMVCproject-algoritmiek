using ClassLib.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Logic
{
    public class Flight
    {
        public FlightDto data { get; }
        public Flight (FlightDto flightDto)
        {
            data = flightDto;
        }

        public int flightId => data.flightId;
        public string AircraftType => data.aircraftType;
        public string departureCountry => data.departureCountry;
        public string arrivalCountry => data.arrivalCountry;
        public DateTime departureTime => data.departureDate;
        public DateTime arrivalTime => data.arrivalDate;
        public bool flightStatus => data.flightStatus;


        private readonly IFlightPersist flight;

        public Flight(IFlightPersist flight)
        {
            this.flight = flight;
        }
        public FlightDto Delete(int id)
        {
           
            throw new System.NotImplementedException();
        }
    }


    /*public int aircraftId { get; set; }
    public string AircraftType { get; set; }
    public string departureCountry { get; set; }
    public string arrivalCountry { get; set; }
    public DateTime departureTime { get; set; }
    public DateTime arrivalTime { get; set; }
    public bool FlightStatus { get; set; }

    public Flight(FlightDto flightDto)
    {
        this.Destination = flightDto.Destination;
        this.AircraftType = flightDto.AircraftType;
        this.FlightStatus = flightDto.FlightStatus;
    }*/
}

