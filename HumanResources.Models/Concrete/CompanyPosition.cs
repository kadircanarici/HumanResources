using HumanResources.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanResources.Models.Concrete
{
    [Table("CompanyPositions")]
    public class CompanyPosition : ModelBase
    {
        public string Name { get; set; }

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }

    }
}