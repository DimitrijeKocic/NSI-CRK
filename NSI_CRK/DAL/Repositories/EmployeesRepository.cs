using NSI_CRK.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NSI_CRK.DAL
{
    public class EmployeesRepository : Repository<Employee>, IEmployeesRepository
    {
        public EmployeesRepository(CRKContext context) : base(context)
        { }

        public IEnumerable<Employee> GetFilteredEmployees(string SearchString = null)
        {
            var employees = crkContext.Employees.AsQueryable();
            if (!String.IsNullOrEmpty(SearchString))
            {
                var toUpper = SearchString.ToUpper();
                employees = crkContext.Employees.Where(e => e.FirstName.Contains(toUpper) ||
                                             e.LastName.Contains(toUpper) ||
                                             e.Email.Contains(toUpper) ||
                                             e.City.Contains(toUpper) ||
                                             e.Salary.ToString().Contains(toUpper) ||
                                             e.Position.ToString().Contains(toUpper));
            }
            return employees;
        }
    }
}