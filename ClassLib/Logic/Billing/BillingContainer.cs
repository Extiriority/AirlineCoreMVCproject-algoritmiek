using ClassLib.Data;
using ClassLib.Interface;
using System.Collections.Generic;
using System.Linq;

namespace ClassLib.Logic
{
    public class BillingContainer
    {
        private readonly IFetchDal<BillingDto> billingContainer;

        public BillingContainer(IFetchDal<BillingDto> billingContainer)
        {
            this.billingContainer = billingContainer;
        }
        public Billing getBillingById(int id) => new Billing(billingContainer.getById(id));
        public Billing verifyLogin(string email, string password) => new Billing(billingContainer.verifyLogin(email, new PasswordHash().passwordHash256(password)));
        public IEnumerable<Billing> getAllBillings() => billingContainer.getAll().Select(billingDto => new Billing(billingDto));
        public IEnumerable<Billing> getAllBillingsById(int id) => billingContainer.getAllByCustomer(id).Select(billingDto => new Billing(billingDto));
    }
}
