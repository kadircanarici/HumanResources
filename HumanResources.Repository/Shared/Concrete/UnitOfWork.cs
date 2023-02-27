using HumanResources.Data;
using HumanResources.Models.Concrete;
using HumanResources.Repository.Shared.Abstract;

namespace HumanResources.Repository.Shared.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IRepository<AppUser> AppUser { get; private set; }
        public IRepository<AppUserRole> AppUserRole { get; private set; }
        public IRepository<Employee> Employee { get; private set; }
        public IRepository<EmployeeDetail> EmployeeDetail { get; private set; }
        public IRepository<EmployeeCompanyPosition> EmployeeCompanyPosition { get; private set; }
        public IRepository<EmployeeEducation> EmployeeEducation { get; private set; }

        public IRepository<Degree> Degree { get; private set; }
        public IRepository<FieldOfStudy> FieldOfStudy { get; private set; }
        public IRepository<EducationProvider> EducationProvider { get; private set; }
        public IRepository<Company> Company { get; private set; }
        public IRepository<CompanyPosition> CompanyPosition { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            AppUser = new Repository<AppUser>(_db);
            AppUserRole = new Repository<AppUserRole>(_db);
            Employee = new Repository<Employee>(_db);
            EmployeeDetail = new Repository<EmployeeDetail>(_db);
            EmployeeCompanyPosition = new Repository<EmployeeCompanyPosition>(_db);
            EmployeeEducation = new Repository<EmployeeEducation>(_db);
            Degree=new Repository<Degree>(_db);
            FieldOfStudy = new Repository<FieldOfStudy>(_db);
            EducationProvider = new Repository<EducationProvider>(_db);
            Company = new Repository<Company>(_db);
            CompanyPosition = new Repository<CompanyPosition>(_db);

        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
