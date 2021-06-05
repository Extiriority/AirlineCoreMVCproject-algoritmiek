using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Interface
{
    public struct TicketDto
    {
        public int ticketId { get; set; }
        public string travelType { get; set; }
        public string classType { get; set; }
        public int numberOfPassengers { get; set; }
    }
}
