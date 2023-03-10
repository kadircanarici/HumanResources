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
        IRepository<Employee> Employee { get; }
        IRepository<EmployeeDetail> EmployeeDetail { get; }
        IRepository<EmployeeCompanyPosition> EmployeeCompanyPosition { get; }
        IRepository<EmployeeEducation> EmployeeEducation { get; }
        IRepository<Degree> Degree { get; }
        IRepository<FieldOfStudy> FieldOfStudy { get; }
        IRepository<EducationProvider> EducationProvider { get; }
        IRepository<Company> Company { get; }
        IRepository<CompanyPosition> CompanyPosition { get; }

        void Save();

    }
}
