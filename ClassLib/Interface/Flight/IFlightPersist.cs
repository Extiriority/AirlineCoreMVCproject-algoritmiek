using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Interface
{
    public interface IFlightPersist
    {
        void save(FlightDto data);
        void delete(int Id);
        void update(FlightDto data);
    }
}
