using ClassLib.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Logic
{
    public class Ticket
    {
        public ITicketPersist ticket;
        public Ticket(ITicketPersist ticket)
        {
            this.ticket = ticket;
        }
        public TicketDto data { get; }

        public Ticket(TicketDto ticketDto)
        {
            data = ticketDto;
        }
        public int ticketId => data.ticketId;
        public string travelType => data.travelType;
        public string classType => data.classType;
        public int numberOfPassengers => data.numberOfPassengers;

        public void save(Ticket ticket) => this.ticket.save(ticket.data);
    }
}

