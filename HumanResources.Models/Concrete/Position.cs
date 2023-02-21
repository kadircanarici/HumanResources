using HumanResources.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanResources.Models.Concrete
{
    [Table("Positions")]
    public class Position : ModelBase
    {
        public string Name { get; set; }

        public virtual Company? Company { get; set; }

        public virtual ICollection<Employee>? Employees { get; set; }
    }
}