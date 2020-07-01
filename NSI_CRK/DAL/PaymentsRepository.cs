using NSI_CRK.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NSI_CRK.DAL
{
    public class PaymentsRepository : GenericRepository<Payment>, IPaymentsRepository
    {
        public PaymentsRepository(CRKContext context) : base(context)
        { }

        public IEnumerable<Payment> GetFilteredPayments(string SearchString = null)
        {
            var payments = crkContext.Payments.AsQueryable();
            if (!String.IsNullOrEmpty(SearchString))
            {
                var toUpper = SearchString.ToUpper();
                payments = crkContext.Payments.Where(s => s.Amount.ToString().Contains(toUpper) ||
                                             s.Type.ToString().Contains(toUpper) ||
                                             s.Month.ToString().Contains(toUpper));
            }
            return payments;
        }
    }
}