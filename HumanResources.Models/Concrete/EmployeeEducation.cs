using HumanResources.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanResources.Models.Concrete
{
    [Table("EmployeeEducations")]
    public class EmployeeEducation : ModelBase
    {
        [ConcurrencyCheck]
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public Guid? EducationProviderId { get; set; }
        public virtual EducationProvider? EducationProvider { get; set; }

        public Guid? DegreeId { get; set; }
        public virtual Degree? Degree { get; set; }

        public Guid? FieldOfStudyId { get; set; }
        public virtual FieldOfStudy? FieldOfStudy { get; set; }

        public DateTime? GraduationDate { get; set; }
    }
}