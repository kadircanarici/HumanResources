﻿using HumanResources.Data;
using HumanResources.Models.Concrete;
using HumanResources.Repository.Shared.Abstract;

namespace HumanResources.Repository.Shared.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IRepository<AppUser> AppUser { get; private set; }
        public IRepository<AppUserRole> AppUserRole { get; private set; }

        public IRepository<Degree> Degree { get; private set; }
        public IRepository<FieldOfStudy> FieldOfStudy { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            AppUser = new Repository<AppUser>(_db);
            AppUserRole = new Repository<AppUserRole>(_db);
            Degree=new Repository<Degree>(_db);
            FieldOfStudy = new Repository<FieldOfStudy>(_db);

        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
