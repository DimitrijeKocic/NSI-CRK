using System;

namespace NSI_CRK.Models
{
    public enum AbsenceType
    {
        PaidVacation,
        UnpaidVacation,
        SickDays,
        MaternityProtection,
        ParentalLeave
    }

    public class Absence
    {
        public int ID { get; set; }

        public AbsenceType Type { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfDays { get; set; }

        public virtual Employee Employee { get; set; }
    }
}