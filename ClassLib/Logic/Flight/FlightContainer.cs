using ClassLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLib.Logic
{
    public class FlightContainer
    {
        private readonly IFlightFetch flightContainer;

        public FlightContainer(IFlightFetch flightContainer)
        {
            this.flightContainer = flightContainer;
        }
        public IEnumerable<Flight> getAll() => flightContainer.getAll().Select(flightDto => new Flight(flightDto));
        public IEnumerable<Flight> searchFlight(string searchString) => flightContainer.searchFlight(searchString).Select(flightDto => new Flight(flightDto));    
        public Flight getById(int id) => new Flight(flightContainer.getById(id));
    }
}
