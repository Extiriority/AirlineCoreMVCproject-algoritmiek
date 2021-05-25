using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Interface.Ticket
{
    public class TicketDto
    {
        public int ticketId { get; set; }
        public string travelType { get; set; }
        public string classType { get; set; }
        public int numberOfPassengers { get; set; }
    }
}
