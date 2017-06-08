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
    }
}
