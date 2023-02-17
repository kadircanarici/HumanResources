using HumanResources.Data;
using HumanResources.Models.Concrete;
using HumanResources.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Repository.Shared.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IRepository<AppUser> AppUser { get; private set; }
        public IRepository<AppUserRole> AppUserRole { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            AppUser = new Repository<AppUser>(_db);
            AppUserRole = new Repository<AppUserRole>(_db);

        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
