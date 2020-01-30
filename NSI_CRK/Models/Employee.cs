using System;
using System.Collections.Generic;

namespace NSI_CRK.Models
{
    public enum PositionType
    {
        JuniorDeveloper,
        MediorDeveloper,
        SeniorDeveloper,
        SoftwareArchitect,
        ProjectManager,
        QAAnalyst,
        HRManager,
        MarketingManager,
        CFO,
        COO,
        CEO
    }

    public class Employee
    {
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public DateTime DateOfContractExpiration { get; set; }
        public PositionType Position { get; set; }
        public double Salary { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Absence> Absences { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}