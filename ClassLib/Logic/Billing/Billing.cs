using ClassLib.Data;
using ClassLib.Interface;
using System;

namespace ClassLib.Logic
{
    public class Billing
    {
        public IPersistDal<BillingDto> billing;
        public Billing(IPersistDal<BillingDto> billing)
        {
            this.billing = billing;
        }
        public BillingDto data { get; }

        public Billing(BillingDto billingDto)
        {
            data = billingDto;
        }
        public int billingId => data.billingId;
        public int FlightId => data.flightId;
        public int CustomerId => data.customerId;
        public int TicketId => data.ticketId;
        public string arrivalCountry => data.arrivalCountry;
        public string firstName => data.firstName;
        public double grandTotal => data.grandTotal;
        public DateTime paymentDate => data.paymentDate;
        public bool paymentStatus => data.paymentStatus;

        public void saveBilling(Billing billing) => this.billing.save(billing.data);
        public int saveBillingAndRetrieveId(Billing billing) => this.billing.saveGetId(billing.data);
        public void deleteBilling(int id) => this.billing.delete(id);
        public void updateBilling(Billing billing) => this.billing.update(billing.data);
    }
}

