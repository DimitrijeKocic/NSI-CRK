using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSI_CRK.Models
{
    public enum PositionType
    {
        [Display(Name = "Junior Developer")]
        JuniorDeveloper,
        [Display(Name = "Medior Developer")]
        MediorDeveloper,
        [Display(Name = "Senior Developer")]
        SeniorDeveloper,
        [Display(Name = "Software Architect")]
        SoftwareArchitect,
        [Display(Name = "Project Manager")]
        ProjectManager,
        [Display(Name = "QA Analyst")]
        QAAnalyst,
        [Display(Name = "HR Manager")]
        HRManager,
        [Display(Name = "Marketing Manager")]
        MarketingManager,
        [Display(Name = "CFO")]
        CFO,
        [Display(Name = "COO")]
        COO,
        [Display(Name = "CEO")]
        CEO
    }

    public class Employee
    {
        public int ID { get; set; }

        [Required, Display(Name = "First Name"), StringLength(30)]
        public string FirstName { get; set; }
        [Required, Display(Name = "Last Name"), StringLength(30)]
        public string LastName { get; set; }
        public string Name
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [Required, DataType(DataType.EmailAddress), StringLength(30)]
        public string Email { get; set; }

        [Required, StringLength(30)]
        public string City { get; set; }

        [Required, StringLength(30)]
        public string Address { get; set; }

        [Required, Display(Name = "Telephone Number"), DataType(DataType.PhoneNumber)]
        public string TelephoneNumber { get; set; }

        [Display(Name = "Date of Birth"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Date of Employment"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfEmployment { get; set; }
        [Display(Name = "Contract Expiration"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfContractExpiration { get; set; }

        public PositionType Position { get; set; }
        public double Salary { get; set; }

        [ForeignKey("Company")]
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Absence> Absences { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}