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
        [Required(ErrorMessage = "An aircraft type is required to proceed!")]
        public string aircraftType { get; set; }
        [Required(ErrorMessage = "A departure country is required to proceed!")]
        public string departureCountry { get; set; }
        [Required(ErrorMessage = "An arrival country is required to proceed!")]
        public string arrivalCountry { get; set; }
        [Required(ErrorMessage = "An departure date is required to proceed!")]
        public DateTime departureDate { get; set; }
        [Required(ErrorMessage = "A arrival date is required to proceed!")]
        public DateTime arrivalDate { get; set; }
        [Required(ErrorMessage = "A flight status is required to proceed!")]
        public bool flightStatus { get; set; }

        public FlightViewModel()
        {

        }
        public FlightViewModel(Flight flight)
        {
            this.flightId = flight.flightId;
            this.aircraftType = flight.aircraftType;
            this.departureCountry = flight.departureCountry;
            this.arrivalCountry = flight.arrivalCountry;
            this.departureDate = flight.departureDate;
            this.arrivalDate = flight.arrivalDate;
            this.flightStatus = flight.flightStatus;

        }
    }
}
