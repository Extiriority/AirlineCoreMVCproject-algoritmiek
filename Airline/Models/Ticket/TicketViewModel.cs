﻿using ClassLib.Logic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airline.Models
{
    public class TicketViewModel
    {
        [Key]
        public int ticketId { get; set; }

        [Required(ErrorMessage = "A travel type is required to proceed!")]
        public string travelType { get; set; }

        [Required(ErrorMessage = "A class type is required to proceed!")]
        public string classType { get; set; }

        [Required(ErrorMessage = "A class type is required to proceed!")]
        public int numberOfPassenger { get; set; }

        public List<FlightViewModel> Flights { get; set; }

        public TicketViewModel()
        {

        }
        public TicketViewModel(Ticket ticket)
        {
            this.ticketId = ticket.ticketId;
            this.travelType = ticket.travelType;
            this.classType = ticket.classType;
            this.numberOfPassenger = ticket.numberOfPassengers;
        }
    }
}
