using System.ComponentModel.DataAnnotations.Schema;

namespace HumanResources.Models.Concrete
{
    [Table("AppUserRoles")]
    public class AppUserRole
    {
        public string Name { get; set; }

    }
}