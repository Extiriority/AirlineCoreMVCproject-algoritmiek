using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Interface.Ticket
{
    public interface ITicketPersist
    {
        void save(TicketDto data);
    }
}
