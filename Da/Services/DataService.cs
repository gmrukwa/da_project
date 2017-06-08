using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.Utils;

namespace Da.Services
{
    class DataService
    {
        public DataService(bool startFromScratch = true)
        {
            if (startFromScratch)
                BuildSampleDatabasePopulation();
        }

        public IEnumerable<T> GetData<T>() where T: Entity
        {
            using (var context = new Context())
            {
                return context.Get<T>().ToList();
            }
            //Site site = new Site() {Address = "1", Name = "1", SiteId = 1, BossId = 1};
            //Employee employee1 = new Employee() { BirthDate = DateTime.Today, EmploymentDate = DateTime.Today, EmployeeId = 1, Name = "1", Position = "1", SiteId = 1, Site = site};
            //site.Boss = employee1;
            //yield return employee1;
            //yield return new Employee() { BirthDate = DateTime.Today, EmploymentDate = DateTime.Today, EmployeeId = 2, Name = "2", Position = "2", SiteId = 1, Site = site };
            //yield return new Employee() { BirthDate = DateTime.Today, EmploymentDate = DateTime.Today, EmployeeId = 3, Name = "3", Position = "3", SiteId = 1, Site = site };
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
