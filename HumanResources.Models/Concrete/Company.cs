using HumanResources.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanResources.Models.Concrete
{
    [Table("Companies")]
    public class Company : ModelBase
    {
        public string Name { get; set; }

    }
}