using HumanResources.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanResources.Models.Concrete
{
    [Table("FieldOfStudies")]
    public class FieldOfStudy : ModelBase
    {
        public string Name { get; set; }

        public virtual ICollection<EmployeeEducation> EmployeeEducations { get; set; }
    }
}