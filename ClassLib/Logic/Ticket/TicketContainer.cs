using ClassLib.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Logic
{
    public class TicketContainer
    {
        private readonly ITicketFetch ticketContainer;

        public TicketContainer(ITicketFetch ticketContainer)
        {
            this.ticketContainer = ticketContainer;
        }
       
        public List<Ticket> getAll()
        {
            List<TicketDto> ticketTemp = ticketContainer.getAll();
            List<Ticket> tickets = new List<Ticket>();

            foreach (TicketDto ticketDto in ticketTemp)
                tickets.Add(new Ticket(ticketDto));

            return tickets;
        }
    }
}
