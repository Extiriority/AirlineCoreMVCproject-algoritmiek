using ClassLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Ticket> getAll() => ticketContainer.getAll().Select(ticketDto => new Ticket(ticketDto));
    }
}

