using HumanResources.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<AppUser> appUsers { get; set; }
        public DbSet<AppUserRole> appUserRoles { get; set; }

        public DbSet<Company> companies { get; set; }
        public DbSet<Degree> degrees { get; set; }
        public DbSet<EducationProvider> educationProviders { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<EmployeeEducation> employeeEducations { get; set; }
        public DbSet<FieldOfStudy> fieldOfStudies { get; set; }
        public DbSet<CompanyPosition> positions { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().Navigation(r => r.AppUserRole).AutoInclude();
            
        }
    }
}
