using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Interface
{
    public interface IFlightFetch
    {
        List<FlightDto> getAll();
        List<FlightDto> searchFlight(string searchString);
        FlightDto getById(int Id);
    }
}
