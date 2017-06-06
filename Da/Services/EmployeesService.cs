using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.Utils;

namespace Da.Services
{
    class EmployeesService
    {
        public IEnumerable<Employee> GetEmployees()
        {
            using (var context = new Context())
            {
                return context.Employees.ToList();
            }
            //Site site = new Site() {Address = "1", Name = "1", SiteId = 1, BossId = 1};
            //Employee employee1 = new Employee() { BirthDate = DateTime.Today, EmploymentDate = DateTime.Today, EmployeeId = 1, Name = "1", Position = "1", SiteId = 1, Site = site};
            //site.Boss = employee1;
            //yield return employee1;
            //yield return new Employee() { BirthDate = DateTime.Today, EmploymentDate = DateTime.Today, EmployeeId = 2, Name = "2", Position = "2", SiteId = 1, Site = site };
            //yield return new Employee() { BirthDate = DateTime.Today, EmploymentDate = DateTime.Today, EmployeeId = 3, Name = "3", Position = "3", SiteId = 1, Site = site };
        }
    }
}
