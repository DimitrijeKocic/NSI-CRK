using NSI_CRK.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NSI_CRK.DAL
{
    public class EmployeesRepository : GenericRepository<Employee>, IEmployeesRepository
    {
        public EmployeesRepository(CRKContext context) : base(context)
        { }

        public IEnumerable<Employee> GetFilteredEmployees(string SearchString = null)
        {
            var employees = crkContext.Employees.AsQueryable();
            if (!String.IsNullOrEmpty(SearchString))
            {
                var toUpper = SearchString.ToUpper();
                employees = crkContext.Employees.Where(s => s.FirstName.Contains(toUpper) ||
                                             s.LastName.Contains(toUpper) ||
                                             s.Email.Contains(toUpper) ||
                                             s.City.Contains(toUpper) ||
                                             s.Salary.ToString().Contains(toUpper) ||
                                             s.Position.ToString().Contains(toUpper));
            }
            return employees;
        }
    }
}