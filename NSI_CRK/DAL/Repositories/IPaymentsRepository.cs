using NSI_CRK.Models;
using System.Collections.Generic;

namespace NSI_CRK.DAL
{
    public interface IPaymentsRepository : IRepository<Payment>
    {
        IEnumerable<Payment> GetFilteredPayments(string SearchString = null);
        void GenerateSalaries(Months month);
    }
}
