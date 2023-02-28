using HumanResources.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanResources.Models.Concrete
{
    [Table("EmployeeCompanyPositions")]
    public class EmployeeCompanyPosition:ModelBase
    {
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public Guid? PositionId { get; set; }
        public virtual CompanyPosition? Position { get; set; }

        public DateTime? HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
    }
}