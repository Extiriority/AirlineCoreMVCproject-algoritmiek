using ClassLib.Interface;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ClassLib.Data
{
    public class TicketDalMsSql : IPersistDal<TicketDto>, IFetchDal<TicketDto>
    {
        public void save(TicketDto data)
        {
            Database.execute(
                "INSERT INTO Ticket (TravelType, CustomerId, ClassType, NumberOfPassengers) VALUES (@travelType, @customerId, @classType, @numberOfPassengers)",
                new
                {
                    data.customerId,
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


        public void update(TicketDto data)
        {
            Database.execute(
                "UPDATE Ticket SET FlightId = @flightId, TravelType = @travelType, ClassType = @classType, NumberOfPassengers = @numberOfPassengers WHERE TicketId = @ticketId",
                new
                {
                    data.ticketId,
                    data.customerId,
                    data.flightId,
                    data.travelType,
                    data.classType,
                    data.numberOfPassengers
                }
            );
        }


        public TicketDto getById(int ticketId)
        {
            var result = Database.query<TicketDto>(
                "SELECT * FROM Ticket WHERE TicketId = @ticketId",
                new
                {
                    ticketId
                }
            ).ToImmutableList();

            return result.Count != 1 ? null : result.Single();
        }

        public IEnumerable<TicketDto> search(string searchString)
        {
            throw new NotImplementedException();
        }

        public TicketDto verifyLogin(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
