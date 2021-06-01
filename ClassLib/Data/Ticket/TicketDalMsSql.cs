using ClassLib.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Data
{
    public class TicketDalMsSql : Database, ITicketPersist
    {
        public void save(TicketDto data)
        {
            try
            {
                string query = "INSERT INTO Ticket (TravelType, ClassType, NumberOfPassengers) " +
                               "VALUES (@travelType, @classType, @numberOfPassengers)";
                databaseConnection(query);

                cmd.Parameters.AddWithValue("@TravelType", data.travelType);
                cmd.Parameters.AddWithValue("@ClassType", data.classType);
                cmd.Parameters.AddWithValue("@NumberOfPassengers", data.numberOfPassengers);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                connClose();
            }
        }
    }
}
