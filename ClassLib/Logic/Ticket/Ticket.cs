using ClassLib.Interface.Ticket;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Logic.Ticket
{
    public class Ticket
    {
        public ITicketPersist ticket;

        public int ticketId { get; set; }
        public string travelType { get; set; }
        public string classType { get; set; }
        public int numberOfPassengers { get; set; }

        public Ticket(TicketDto data)
        {
            this.ticketId           = data.ticketId;
            this.travelType         = data.travelType;
            this.classType          = data.classType;
            this.numberOfPassengers = data.numberOfPassengers;
        }

        public Ticket(ITicketPersist ticket)
        {
            this.ticket = ticket;
        }

        public void Save()
        {
            TicketDto data = new TicketDto
            {
                ticketId = this.ticketId,
                travelType = this.travelType,
                classType = this.classType,
                numberOfPassengers = this.numberOfPassengers
            };
            ticket.save(data);
        }
    }
}
