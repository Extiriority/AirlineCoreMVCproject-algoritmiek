using ClassLib.Logic.Ticket;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        public int numberOfpassenger { get; set; }

        public TicketViewModel()
        {

        }
        public TicketViewModel(Ticket ticket)
        {
            this.ticketId = ticket.ticketId;
            this.travelType = ticket.travelType;
            this.classType = ticket.classType;
            this.numberOfpassenger = ticket.numberOfPassengers;
        }
    }
}
