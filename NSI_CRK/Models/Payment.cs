using System;

namespace NSI_CRK.Models
{
    public enum PaymentType
    {
        FixSalary,
        OvertimeWork,
        TransportSubsidy,
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
        public DateTime Date { get; set; }

        public virtual Employee Employee { get; set; }
    }
}