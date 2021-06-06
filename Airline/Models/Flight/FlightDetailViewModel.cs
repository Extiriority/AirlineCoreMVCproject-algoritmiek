using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Airline.Models
{
    public class FlightDetailViewModel
    {
        public List<FlightViewModel> Flights { get; set; }

        [BindProperty(SupportsGet = true)]
        public string searchString { get; set; }
    }
}
