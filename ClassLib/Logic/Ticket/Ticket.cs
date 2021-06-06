using ClassLib.Data;
using ClassLib.Interface;

namespace ClassLib.Logic
{
    public class Ticket
    {
        public IPersistDal<TicketDto> ticket;
        public Ticket(IPersistDal<TicketDto> ticket)
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

        public void saveTicket(Ticket ticket) => this.ticket.save(ticket.data);
    }
}

