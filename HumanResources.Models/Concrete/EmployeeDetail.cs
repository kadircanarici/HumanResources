using HumanResources.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Models.Concrete
{
    [Table("EmployeeDetails")]
    public class EmployeeDetail:ModelBase
    {
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? DriverLicense { get; set; }
        public string? MilitaryObligations { get; set; }
        public string ? Gender { get; set; }
        public bool? MaritalStatus { get; set; }


    }
}
