using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Interface
{
    public interface IFlightPersist
    {
        void save(FlightDto flight);
        void delete(int Id);
        void update(FlightDto flight);
    }
}
