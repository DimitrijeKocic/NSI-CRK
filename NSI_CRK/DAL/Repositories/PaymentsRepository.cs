using NSI_CRK.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NSI_CRK.DAL
{
    public class PaymentsRepository : Repository<Payment>, IPaymentsRepository
    {
        public PaymentsRepository(CRKContext context) : base(context)
        { }

        public IEnumerable<Payment> GetFilteredPayments(string SearchString = null)
        {
            var payments = crkContext.Payments.AsQueryable();
            if (!String.IsNullOrEmpty(SearchString))
            {
                var toUpper = SearchString.ToUpper();
                payments = crkContext.Payments.Where(p => (p.Employee.FirstName.ToString() + " " + p.Employee.LastName.ToString()).Contains(toUpper) ||
                                                    p.Type.ToString().Contains(toUpper) ||
                                                    p.Month.ToString().Contains(toUpper));
            }
            return payments;
        }

        public void GenerateSalaries(Months month)
        {
            var employees = crkContext.Employees;
            foreach (Employee employee in employees)
            {
                var payment = new Payment()
                {
                    EmployeeID = employee.ID,
                    Type = PaymentType.FixSalary,
                    Amount = employee.Salary,
                    Month = month,
                    Date = DateTime.Now
                };
                crkContext.Payments.Add(payment);
            }
        }
    }
}