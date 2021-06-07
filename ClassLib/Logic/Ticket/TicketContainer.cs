﻿using ClassLib.Data;
using ClassLib.Interface;
using System.Collections.Generic;
using System.Linq;

namespace ClassLib.Logic
{
    public class TicketContainer
    {
        private readonly IFetchDal<TicketDto> ticketContainer;

        public TicketContainer(IFetchDal<TicketDto> ticketContainer)
        {
            this.ticketContainer = ticketContainer;
        }      
        public IEnumerable<Ticket> getAllTickets() => ticketContainer.getAll().Select(ticketDto => new Ticket(ticketDto));
    }
}

