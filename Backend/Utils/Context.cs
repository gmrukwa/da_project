using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Entities;

namespace Backend.Utils
{
    public class Context: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Vacation> Vacations { get; set; }

        public T Get<T>(int id) where T : Entity
        {
            // @gmrukwa .ToList enforces local calls
            return Get<T>().ToList().First(e => e.GetId() == id);

            //if (typeof(T) == typeof(Employee))
            //    return Get<Employee>().First(e => e.EmployeeId == id) as T;
            //if (typeof(T) == typeof(Project))
            //    return Get<Project>().First(p => p.ProjectId == id) as T;
            //if (typeof(T) == typeof(Salary))
            //    return Get<Salary>().First(s => s.SalaryId == id) as T;
            //if (typeof(T) == typeof(Site))
            //    return Get<Site>().First(s => s.SiteId == id) as T;
            //if (typeof(T) == typeof(Vacation))
            //    return Get<Vacation>().First(v => v.VacationId == id) as T;
            //throw new TypeAccessException(typeof(T).AssemblyQualifiedName);
        }

        public DbSet<T> Get<T>() where T : Entity
        {
            if (typeof(T) == typeof(Employee))
                return Employees as DbSet<T>;
            if (typeof(T) == typeof(Project))
                return Projects as DbSet<T>;
            if (typeof(T) == typeof(Salary))
                return Salaries as DbSet<T>;
            if (typeof(T) == typeof(Site))
                return Sites as DbSet<T>;
            if (typeof(T) == typeof(Vacation))
                return Vacations as DbSet<T>;
            throw new TypeAccessException(typeof(T).AssemblyQualifiedName);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Vacation>().HasRequired(v => v.Employee).WithMany().WillCascadeOnDelete();
            //modelBuilder.Entity<Site>().HasOptional(s => s.Boss).WithMany().WillCascadeOnDelete();
            //modelBuilder.Entity<Project>().HasOptional(p => p.Manager).WithMany().WillCascadeOnDelete();
            modelBuilder.Entity<Salary>().HasRequired(s => s.Employee).WithMany().WillCascadeOnDelete();
            modelBuilder.Entity<Salary>().HasRequired(s => s.Project).WithMany().WillCascadeOnDelete();
        }
    }
}
