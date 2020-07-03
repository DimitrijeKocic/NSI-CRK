using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSI_CRK.Models
{
    public enum AbsenceType
    {
        [Display(Name = "Paid Vacation")]
        PaidVacation,
        [Display(Name = "Unpaid Vacation")]
        UnpaidVacation,
        [Display(Name = "Sick Days")]
        SickDays,
        [Display(Name = "Maternity Protection")]
        MaternityProtection,
        [Display(Name = "Parental Leave")]
        ParentalLeave
    }

    public class Absence
    {
        public int ID { get; set; }

        public AbsenceType Type { get; set; }

        [Display(Name = "Begin Date"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BeginDate { get; set; }
        [Display(Name = "End Date"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Number of Days")]
        public int NumberOfDays { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
    }
}