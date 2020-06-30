using NSI_CRK.Models;
using System.Collections.Generic;

namespace NSI_CRK.DAL
{
    public interface IPaymentsRepository : IGenericRepository<Payment>
    {
        IEnumerable<Payment> GetFilteredPayments(string SearchString = null);
    }
}
