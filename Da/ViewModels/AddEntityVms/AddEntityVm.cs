using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Entities;
using Spectre.Mvvm.Base;

namespace Da.ViewModels.AddEntityVms
{
    abstract class AddEntityVm<T>: PropertyChangedNotification, IAddEntityVm where T: Entity
    {
        public static AddEntityVm<T> GetVm<T>(T entity) where T: Entity
        {
            if (typeof(T) == typeof(Employee))
                return new EmployeeVm(entity as Employee) as AddEntityVm<T>;
            if (typeof(T) == typeof(Project))
                return new ProjectVm(entity as Project) as AddEntityVm<T>;
            if (typeof(T) == typeof(Salary))
                return new SalaryVm(entity as Salary) as AddEntityVm<T>;
            if (typeof(T) == typeof(Site))
                return new SiteVm(entity as Site) as AddEntityVm<T>;
            if (typeof(T) == typeof(Vacation))
                return new VacationVm(entity as Vacation) as AddEntityVm<T>;
            throw new TypeAccessException(typeof(T).AssemblyQualifiedName);
        }
    }
}
