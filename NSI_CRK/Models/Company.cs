using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NSI_CRK.Models
{
    public class Company
    {
        public int ID { get; set; }

        public string Name { get; set; }

        [StringLength(3), DataType(DataType.Currency)]
        public string Currency { get; set; }

        public int NumberOfEmployees { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

    }
}