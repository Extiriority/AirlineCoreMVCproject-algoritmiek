using ClassLib.Interface;
using System;
using System.Collections.Generic;

namespace ClassLib.Data
{
    public class TicketDalMsSql : IPersistDal<TicketDto>, IFetchDal<TicketDto>
    {
        public void save(TicketDto data)
        {
            Database.execute(
                "INSERT INTO Ticket (TravelType, ClassType, NumberOfPassengers) VALUES (@travelType, @classType, @numberOfPassengers)",
                new
                {
                    data.travelType,
                    data.classType,
                    data.numberOfPassengers
                }
            );
        }
        public IEnumerable<TicketDto> getAll() => Database.query<TicketDto>("SELECT * FROM Ticket");

        public void delete(int ticketId)
        {
            Database.execute(
                "DELETE FROM Ticket WHERE TicketId = @ticketId",
                new
                {
                    ticketId
                }
             );
        }


        public void update(TicketDto t)
        {
            throw new NotImplementedException();
        }


        public TicketDto getById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketDto> search(string searchString)
        {
            throw new NotImplementedException();
        }

        public bool verifyLogin(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
