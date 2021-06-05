using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Interface
{
    public interface IFlightFetch
    {
        IEnumerable<FlightDto> getAll();
        IEnumerable<FlightDto> searchFlight(string searchString);
        FlightDto getById(int Id);
    }
}
