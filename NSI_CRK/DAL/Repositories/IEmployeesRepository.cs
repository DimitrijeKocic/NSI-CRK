using NSI_CRK.Models;
using System.Collections.Generic;

namespace NSI_CRK.DAL
{
    public interface IEmployeesRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetFilteredEmployees(string SearchString = null);
    }
}
