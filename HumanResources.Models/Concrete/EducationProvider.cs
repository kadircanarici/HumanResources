using HumanResources.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanResources.Models.Concrete
{
    [Table("EducationProviders")]
    public class EducationProvider : ModelBase
    {
        public string Name { get; set; }

        public virtual ICollection<EmployeeEducation> EmployeeEducations { get; set; }
    }

}