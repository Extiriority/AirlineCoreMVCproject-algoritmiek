using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Models
{
    public class FlightDetailViewModel
    {
        public List<FlightViewModel> Flights { get; set; }

        [BindProperty(SupportsGet = true)]
        public string searchString { get; set; }
    }
}
