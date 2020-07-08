namespace NSI_CRK.Migrations
{
    using NSI_CRK.Models;
    using NSI_CRK.DAL;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CRKContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CRKContext context)
        {
            var company = new Company { Name = "SkyNet", Currency = "EUR", NumberOfEmployees = 7 };
            context.Companies.AddOrUpdate(c => c.Name, company);
            context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee { FirstName = "Slobodan", LastName = "Micić", Email = "slobodan.micic@skynet.rs", City = "Beograd", Address = "Takovsa 18", TelephoneNumber = "0602658847",
                    DateOfBirth = DateTime.Parse("1994-02-08"), DateOfEmployment = DateTime.Parse("2018-08-16"), DateOfContractExpiration = DateTime.Parse("2023-08-16"),
                    Position = PositionType.JuniorDeveloper, Salary = 1000, CompanyID = company.ID },
                new Employee { FirstName = "Stefan", LastName = "Kojić", Email = "stefan.kojic@skynet.rs", City = "Novi Sad", Address = "Mihajla Obrenovića 56/12", TelephoneNumber = "0651125454",
                    DateOfBirth = DateTime.Parse("1994-07-12"), DateOfEmployment = DateTime.Parse("2018-10-28"), DateOfContractExpiration = DateTime.Parse("2023-10-28"),
                    Position = PositionType.JuniorDeveloper, Salary = 1000, CompanyID = company.ID },
                new Employee { FirstName = "Milan", LastName = "Stojaković", Email = "milan.stojakovic@skynet.rs", City = "Beograd", Address = "Pariske Komune 35/22", TelephoneNumber = "0634885931",
                    DateOfBirth = DateTime.Parse("1990-01-07"), DateOfEmployment = DateTime.Parse("2017-01-31"), DateOfContractExpiration = DateTime.Parse("2027-01-31"),
                    Position = PositionType.MediorDeveloper, Salary = 1700, CompanyID = company.ID },
                new Employee { FirstName = "Milan", LastName = "Rajković", Email = "milan.rajkovic@skynet.rs", City = "Beograd", Address = "Milutina Milankovića 11/29", TelephoneNumber = "0605744481",
                    DateOfBirth = DateTime.Parse("1987-09-18"), DateOfEmployment = DateTime.Parse("2012-10-05"), DateOfContractExpiration = DateTime.Parse("2024-10-05"),
                    Position = PositionType.SeniorDeveloper, Salary = 2500, CompanyID = company.ID },
                new Employee { FirstName = "Vladan", LastName = "Petković", Email = "vladan.petkovic@skynet.rs", City = "Beograd", Address = "Bulevar Nemanjića 11/11", TelephoneNumber = "0642218876",
                    DateOfBirth = DateTime.Parse("1982-06-12"), DateOfEmployment = DateTime.Parse("2014-05-17"), DateOfContractExpiration = DateTime.Parse("2024-05-17"),
                    Position = PositionType.SoftwareArchitect, Salary = 3000, CompanyID = company.ID },
                new Employee { FirstName = "Andrija", LastName = "Dražić", Email = "andrija.drazic@skynet.rs", City = "Beograd", Address = "Jurija Gagarina 45", TelephoneNumber = "0661212633",
                    DateOfBirth = DateTime.Parse("1972-03-18"), DateOfEmployment = DateTime.Parse("2010-07-13"), DateOfContractExpiration = DateTime.Parse("2024-07-13"),
                    Position = PositionType.ProjectManager, Salary = 2500, CompanyID = company.ID },
                new Employee { FirstName = "Dejan", LastName = "Đorđević", Email = "dejan.djordjevic@skynet.rs", City = "Beograd", Address = "Omladinskih Brigada 7/9", TelephoneNumber = "0602327597",
                    DateOfBirth = DateTime.Parse("1974-09-18"), DateOfEmployment = DateTime.Parse("2010-07-10"), DateOfContractExpiration = DateTime.Parse("2020-10-07"),
                    Position = PositionType.CEO, Salary = 4000, CompanyID = company.ID }
            };
            employees.ForEach(employee => context.Employees.AddOrUpdate(e => new { e.FirstName, e.LastName }, employee));
            context.SaveChanges();

            var payments = new List<Payment>
            {
                new Payment { Amount = 1000, Type = PaymentType.FixSalary, Month = Months.December, Date = DateTime.Parse("2020-01-10"),
                    EmployeeID = employees.Single(e => (e.FirstName == "Slobodan" && e.LastName == "Micić")).ID },
                new Payment { Amount = 1000, Type = PaymentType.FixSalary, Month = Months.December, Date = DateTime.Parse("2020-01-11"),
                    EmployeeID = employees.Single(e => (e.FirstName == "Stefan" && e.LastName == "Kojić")).ID },
                new Payment { Amount = 1700, Type = PaymentType.FixSalary, Month = Months.December, Date = DateTime.Parse("2020-01-10"),
                    EmployeeID = employees.Single(e => (e.FirstName == "Milan" && e.LastName == "Stojaković")).ID },
                new Payment { Amount = 2500, Type = PaymentType.FixSalary, Month = Months.December, Date = DateTime.Parse("2020-01-10"),
                    EmployeeID = employees.Single(e => (e.FirstName == "Milan" && e.LastName == "Rajković")).ID },
                new Payment { Amount = 3000, Type = PaymentType.FixSalary, Month = Months.December, Date = DateTime.Parse("2020-01-10"),
                    EmployeeID = employees.Single(e => (e.FirstName == "Vladan" && e.LastName == "Petković")).ID },
                new Payment { Amount = 2500, Type = PaymentType.FixSalary, Month = Months.December, Date = DateTime.Parse("2020-01-10"),
                    EmployeeID = employees.Single(e => (e.FirstName == "Andrija" && e.LastName == "Dražić")).ID },
                new Payment { Amount = 4000, Type = PaymentType.FixSalary, Month = Months.December, Date = DateTime.Parse("2020-01-10"),
                    EmployeeID = employees.Single(e => (e.FirstName == "Dejan" && e.LastName == "Đorđević")).ID },
                new Payment { Amount = 150, Type = PaymentType.TransportSubsidy, Date = DateTime.Parse("2020-01-15"),
                    EmployeeID = employees.Single(e => (e.FirstName == "Stefan" && e.LastName == "Kojić")).ID },
                new Payment { Amount = 200, Type = PaymentType.OvertimeWork, Date = DateTime.Parse("2020-01-20"),
                    EmployeeID = employees.Single(e => (e.FirstName == "Vladan" && e.LastName == "Petković")).ID },
                new Payment { Amount = 250, Type = PaymentType.OvertimeWork, Date = DateTime.Parse("2020-01-20"),
                    EmployeeID = employees.Single(e => (e.FirstName == "Slobodan" && e.LastName == "Micić")).ID },
                new Payment { Amount = 200, Type = PaymentType.OvertimeWork, Date = DateTime.Parse("2020-01-21"),
                    EmployeeID = employees.Single(e => (e.FirstName == "Stefan" && e.LastName == "Kojić")).ID },
                new Payment { Amount = 750, Type = PaymentType.Other, Date = DateTime.Parse("2020-01-15"),
                    EmployeeID = employees.Single(e => (e.FirstName == "Milan" && e.LastName == "Rajković")).ID }
            };
            payments.ForEach(payment => context.Payments.AddOrUpdate(p => new { p.Amount, p.Date }, payment));
            context.SaveChanges();

            var absences = new List<Absence>
            {
                new Absence { Type = AbsenceType.PaidVacation, BeginDate = DateTime.Parse("2019-12-09"), EndDate = DateTime.Parse("2019-12-20"),
                    NumberOfDays = 10, EmployeeID = employees.Single(e => (e.FirstName == "Slobodan" && e.LastName == "Micić")).ID },
                new Absence { Type = AbsenceType.PaidVacation, BeginDate = DateTime.Parse("2019-12-30"), EndDate = DateTime.Parse("2020-01-08"),
                    NumberOfDays = 5, EmployeeID = employees.Single(e => (e.FirstName == "Vladan" && e.LastName == "Petković")).ID },
                new Absence { Type = AbsenceType.PaidVacation, BeginDate = DateTime.Parse("2019-12-30"), EndDate = DateTime.Parse("2020-01-09"),
                    NumberOfDays = 6, EmployeeID = employees.Single(e => (e.FirstName == "Stefan" && e.LastName == "Kojić")).ID },
                new Absence { Type = AbsenceType.PaidVacation, BeginDate = DateTime.Parse("2020-01-06"), EndDate = DateTime.Parse("2020-01-17"),
                    NumberOfDays = 6, EmployeeID = employees.Single(e => (e.FirstName == "Milan" && e.LastName == "Rajković")).ID },
                new Absence { Type = AbsenceType.SickDays, BeginDate = DateTime.Parse("2020-01-16"), EndDate = DateTime.Parse("2020-01-24"),
                    NumberOfDays = 7, EmployeeID = employees.Single(e => (e.FirstName == "Stefan" && e.LastName == "Kojić")).ID },
            };
            absences.ForEach(absence => context.Absences.AddOrUpdate(a => new { a.BeginDate, a.EndDate }, absence));
            context.SaveChanges();
        }
    }
}
