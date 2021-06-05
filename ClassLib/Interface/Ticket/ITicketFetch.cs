using ClassLib.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Interface
{
    public interface ITicketFetch
    {
        IEnumerable<TicketDto> getAll();
    }
}
