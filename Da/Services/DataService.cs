using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Backend.Entities;
using Backend.Utils;

namespace Da.Services
{
    class DataService
    {
        public DataService(bool startFromScratch = false)
        {
            if (startFromScratch)
                BuildSampleDatabasePopulation();
        }

        public IEnumerable<T> GetData<T>() where T: Entity
        {
            using (var context = new Context())
            {
                return context.Get<T>();
            }
        }

        public IEnumerable<T> GetData<T>(Context context) where T : Entity
        {
            return context.Get<T>();
        }

        // @gmrukwa: This one is useful for downloading lazily fetched deps
        public void GetData<T>(Action<DbSet<T>, Exception> callback) where T : Entity
        {
            using (var context = new Context())
            {
                try
                {
                    callback(context.Get<T>(), null);
                }
                catch (Exception ex)
                {
                    callback(null, ex);
                }
            }
        }

        private void BuildSampleDatabasePopulation()
        {
            using (var context = new Context())
            {
                context.Database.Delete();
                var site = new Site() { Address = "Somewhere", Name = "Site 1" };
                context.Sites.Add(site);
                context.SaveChanges();

                var employee1 = new Employee() { BirthDate = DateTime.Today, EmploymentDate = DateTime.Today, Name = "Jacek Bajer", Position = "Nikt", Site = site };
                site.Boss = employee1;
                context.Employees.Add(employee1);
                context.SaveChanges();

                var employee2 = new Employee() { BirthDate = DateTime.Today, EmploymentDate = DateTime.Today, Name = "Andriej Dudeł", Position = "Pachołek", Site = site };
                context.Employees.Add(employee2);
                context.SaveChanges();

                var project = new Project() { Description = "No one does a duck here.", Name="A project", Manager = employee1, StartDate = DateTime.Today };
                context.Projects.Add(project);
                context.SaveChanges();

                var vacation = new Vacation() { BeginningDate = DateTime.Today + TimeSpan.FromDays(1), EndDate = DateTime.Today + TimeSpan.FromDays(10), Employee = employee1 };
                context.Vacations.Add(vacation);
                context.SaveChanges();

                var salary = new Salary() { Amount = 0, Date = DateTime.Today, Employee = employee2, Paid = false, Project = project };
                context.Salaries.Add(salary);
                context.SaveChanges();
            }
        }
    }
}
