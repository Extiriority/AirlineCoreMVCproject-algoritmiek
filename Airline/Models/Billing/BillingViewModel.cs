using ClassLib.Interface;
using ClassLib.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Models
{
    public class BillingViewModel
    {
        public BillingViewModel() {}

        public int billingId { get; set; }
        public string arrivalCountry { get; set; }
        public string firstName { get; set; }
        public Ticket ticket { get; set; }
        public double grandTotal { get; set; }
        public DateTime paymentDate { get; set; }
        public bool paymentStatus { get; set; }

        public BillingViewModel(Billing billing)
        {
            this.billingId = billing.billingId;
            this.arrivalCountry = billing.arrivalCountry;
            this.firstName = billing.firstName;
            this.grandTotal = billing.grandTotal;
            this.paymentDate = billing.paymentDate;
            this.paymentStatus = billing.paymentStatus;
        }
    }
}
