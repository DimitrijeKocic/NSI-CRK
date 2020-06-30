using NSI_CRK.Models;
using System.Collections.Generic;

namespace NSI_CRK.DAL
{
    public interface IAbsencesRepository : IGenericRepository<Absence>
    {
        IEnumerable<Absence> GetFilteredAbsences(string SearchString = null);
    }
}
