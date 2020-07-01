using NSI_CRK.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NSI_CRK.DAL
{
    public class AbsencesRepository : GenericRepository<Absence>, IAbsencesRepository
    {
        public AbsencesRepository(CRKContext context) : base(context)
        { }

        public IEnumerable<Absence> GetFilteredAbsences(string SearchString = null)
        {
            var absences = crkContext.Absences.AsQueryable();
            if (!String.IsNullOrEmpty(SearchString))
            {
                var toUpper = SearchString.ToUpper();
                absences = crkContext.Absences.Where(s => s.Type.ToString().Contains(toUpper));
            }
            return absences;
        }
    }
}