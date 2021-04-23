using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Interface
{
    public interface IFlightFetch
    {
        List<FlightDto> getAll();

        FlightDto getById(int id);
    }
}
