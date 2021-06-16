using ClassLib.Interface;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace ClassLib.Data
{
    public class BillingDalMsSql : IPersistDal<BillingDto>, IFetchDal<BillingDto>
    {
        public void delete(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<BillingDto> getAllByCustomer(int billingId)
        {
            var result = Database.query<BillingDto>(
                "SELECT Billing.BillingId, Customer.FirstName, Flight.ArrivalCountry, Billing.GrandTotal, Billing.PaymentStatus FROM ((Billing INNER JOIN Customer ON Billing.CustomerId = Customer.CustomerId) INNER JOIN Flight ON Billing.FlightId = Flight.FlightId WHERE Billing.BillingId=@billingId",
                new
                {
                    billingId
                }
            ).ToImmutableList();
            return result;
        }
        
           
        

        public BillingDto getById(int id)
        {
            throw new NotImplementedException();
        }

        public void save(BillingDto data)
        {
            Database.execute(
                "INSERT INTO Billing (FlightId, CustomerId, TicketId, GrandTotal, PaymentDate, PaymentStatus) VALUES (@flightId, @customerId, @ticketId, @grandTotal, @paymentDate, @paymentStatus)",
                new
                {
                    data.flightId,
                    data.customerId,
                    data.ticketId,
                    data.grandTotal,
                    data.paymentDate,
                    data.paymentStatus
                }
            );
        }

        public IEnumerable<BillingDto> getAll() {
            throw new NotImplementedException();
        }
        public int saveGetId(BillingDto t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BillingDto> search(string searchString)
        {
            throw new NotImplementedException();
        }

        public void update(BillingDto t)
        {
            throw new NotImplementedException();
        }

        public BillingDto verifyLogin(string email, string password)
        {
            throw new NotImplementedException();
        }

        
    }
}
