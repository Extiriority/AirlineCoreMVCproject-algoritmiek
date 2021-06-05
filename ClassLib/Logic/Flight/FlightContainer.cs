using ClassLib.Data;
using ClassLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLib.Logic
{
    public class FlightContainer
    {
        private readonly IFetchDal<FlightDto> flightContainer;

        public FlightContainer(IFetchDal<FlightDto> flightContainer)
        {
            this.flightContainer = flightContainer;
        }
        public IEnumerable<Flight> getAll() => flightContainer.getAll().Select(flightDto => new Flight(flightDto));
        public IEnumerable<Flight> searchFlight(string searchString) => flightContainer.search(searchString).Select(flightDto => new Flight(flightDto));    
        public Flight getById(int id) => new Flight(flightContainer.getById(id));
    }
}
