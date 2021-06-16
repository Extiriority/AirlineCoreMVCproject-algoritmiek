using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Models
{
    public class BillingViewModel
    {
        public List<CustomerViewModel> customers { get; set; }
        public List<FlightViewModel> flights { get; set; }
        public List<TicketViewModel> tickets { get; set; }
    }
}
