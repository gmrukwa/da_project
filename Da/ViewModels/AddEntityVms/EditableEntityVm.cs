using System;
using Backend.Entities;
using Da.Services;
using Spectre.Mvvm.Base;

namespace Da.ViewModels.AddEntityVms
{
    abstract class EditableEntityVm<T>: PropertyChangedNotification, IAddEntityVm where T: Entity, new()
    {
        public static EditableEntityVm<T> GetVm<T>(T entity, DataService dataService) where T: Entity, new()
        {
            if (typeof(T) == typeof(Employee))
                return new EmployeeVm(entity as Employee, dataService) as EditableEntityVm<T>;
            if (typeof(T) == typeof(Project))
                return new ProjectVm(entity as Project, dataService) as EditableEntityVm<T>;
            if (typeof(T) == typeof(Salary))
                return new SalaryVm(entity as Salary, dataService) as EditableEntityVm<T>;
            if (typeof(T) == typeof(Site))
                return new SiteVm(entity as Site, dataService) as EditableEntityVm<T>;
            if (typeof(T) == typeof(Vacation))
                return new VacationVm(entity as Vacation, dataService) as EditableEntityVm<T>;
            throw new TypeAccessException(typeof(T).AssemblyQualifiedName);
        }

        public T Entity { get { return GetValue(() => Entity); } set { SetValue(() => Entity, value); } }

        protected EditableEntityVm(T entity, DataService dataService)
        {
            Entity = entity;
            DataService = dataService;
        }

        protected readonly DataService DataService;
    }
}
