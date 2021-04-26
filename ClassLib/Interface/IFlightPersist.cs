using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Interface
{
    public interface IFlightPersist
    {
        bool create(FlightDto flight);
        void save(FlightDto flight);
        bool delete(int Id);

    }
}
