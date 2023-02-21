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
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public Guid PositionId { get; set; }
        public virtual Position Position { get; set; }

        public virtual ICollection<EmployeeEducation> EmployeeEducations { get; set; }
    }
}
