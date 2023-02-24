using HumanResources.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Models.Concrete
{
    [Table("Employees")]
    public class Employee : ModelBase
    {
        public string Tc { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual ICollection<EmployeeCompanyPosition> EmployeeCompanyPositions { get; set; }

        public virtual ICollection<EmployeeDetail> EmployeeDetails { get; set; }

        public virtual ICollection<EmployeeEducation> EmployeeEducations { get; set; }
    }
}
