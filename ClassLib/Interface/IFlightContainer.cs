using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Interface
{
    public interface IFlightContainer
    {
        public List<FlightDTO> GetAllFlights();
    }
}
