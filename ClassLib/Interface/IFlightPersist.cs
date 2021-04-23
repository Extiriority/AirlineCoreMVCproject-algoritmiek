using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Interface
{
    interface IFlightPersist
    {
        void save(FlightDto flight);
        void delete(int id);
    }
}
