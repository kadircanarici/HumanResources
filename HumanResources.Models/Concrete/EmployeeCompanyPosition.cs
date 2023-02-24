using HumanResources.Models.Abstract;

namespace HumanResources.Models.Concrete
{
    public class EmployeeCompanyPosition:ModelBase
    {
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public Guid PositionId { get; set; }
        public virtual CompanyPosition Position { get; set; }

        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
    }
}