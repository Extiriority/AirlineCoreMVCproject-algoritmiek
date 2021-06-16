using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Interface
{
    public class BillingDto
    {
        public int billingId { get; set; }
        public int flightId { get; set; }
        public int customerId { get; set; }
        public int ticketId { get; set; }
        public int grandTotal { get; set; }
        public DateTime paymentDate { get; set; }
        public bool paymentStatus { get; set; }
    }
}
