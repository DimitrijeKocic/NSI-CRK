using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSI_CRK.Models
{
    public enum PaymentType
    {
        [Display(Name = "Fix Salary")]
        FixSalary,
        [Display(Name = "Overtime Work")]
        OvertimeWork,
        [Display(Name = "Transport Subsidy")]
        TransportSubsidy,
        [Display(Name = "Other")]
        Other
    }

    public enum Months
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }

    public class Payment
    {
        public int ID { get; set; }

        public double Amount { get; set; }
        public PaymentType Type { get; set; }
        public Months Month { get; set; }

        [Display(Name = "Date of Payment"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
    }
}