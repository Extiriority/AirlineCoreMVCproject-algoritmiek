using ClassLib.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Models
{
    public class FlightViewModel
    {
        [Key]
        public int flightId { get; set; }
        public string aircraftType { get; set; }
        public string departureCountry { get; set; }
        public string arrivalCountry { get; set; }
        public DateTime departureDate { get; set; }
        public DateTime arrivalDate { get; set; }
        public bool flightStatus { get; set; }

        public FlightViewModel(Flight flight)
        {
            this.flightId = flight.flightId;
            this.aircraftType = flight.AircraftType;
            this.departureCountry = flight.departureCountry;
            this.arrivalCountry = flight.arrivalCountry;
            this.departureDate = flight.departureTime;
            this.arrivalDate = flight.arrivalTime;
            this.flightStatus = flight.flightStatus;

        }
    }
}
