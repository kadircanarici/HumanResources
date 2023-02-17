using HumanResources.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanResources.Models.Concrete
{
    [Table("AppUserRoles")]
    public class AppUserRole:ModelBase
    {
        public string Name { get; set; }

    }
}