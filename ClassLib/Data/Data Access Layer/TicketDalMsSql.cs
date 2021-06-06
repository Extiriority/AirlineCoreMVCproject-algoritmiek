using ClassLib.Interface;
using System;

namespace ClassLib.Data
{
    public class TicketDalMsSql : IPersistDal<TicketDto>
    {
        public void save(TicketDto data)
        {
            Database.execute(
                "INSERT INTO Ticket (TravelType, ClassType, NumberOfPassengers) VALUES (@travelType, @classType, @numberOfPassengers) ON CONFLICT (TicketId) DO UPDATE SET TravelType = @travelType, ClassType = @classType, NumberOfPassengers = @numberOfPassengers",
                new
                {
                    data.travelType,
                    data.classType,
                    data.numberOfPassengers
                }
            );
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }


        public void update(TicketDto t)
        {
            throw new NotImplementedException();
        }
    }
}
