using HumanResources.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Repository.Shared.Abstract
{
    public interface IUnitOfWork
    {
        IRepository<AppUser> AppUser { get; }
        IRepository<AppUserRole> AppUserRole { get; }
        IRepository<Degree> Degree { get; }
        IRepository<FieldOfStudy> FieldOfStudy { get; }
        IRepository<EducationProvider> EducationProvider { get; }

        void Save();

    }
}
