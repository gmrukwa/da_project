using System;
using Backend.Entities;
using Backend.Utils;
using Da.Services;
using Spectre.Mvvm.Base;

namespace Da.ViewModels.AddEntityVms
{
    abstract class EditableEntityVm<T>: PropertyChangedNotification, IAddEntityVm where T: Entity, new()
    {
        public static EditableEntityVm<T> GetVm<T>(T entity, DataService dataService, Context context) where T: Entity, new()
        {
            if (typeof(T) == typeof(Employee))
                return new EmployeeVm(entity as Employee, dataService, context) as EditableEntityVm<T>;
            if (typeof(T) == typeof(Project))
                return new ProjectVm(entity as Project, dataService, context) as EditableEntityVm<T>;
            if (typeof(T) == typeof(Salary))
                return new SalaryVm(entity as Salary, dataService, context) as EditableEntityVm<T>;
            if (typeof(T) == typeof(Site))
                return new SiteVm(entity as Site, dataService, context) as EditableEntityVm<T>;
            if (typeof(T) == typeof(Vacation))
                return new VacationVm(entity as Vacation, dataService, context) as EditableEntityVm<T>;
            throw new TypeAccessException(typeof(T).AssemblyQualifiedName);
        }

        public T Entity { get { return GetValue(() => Entity); } set { SetValue(() => Entity, value); } }

        protected EditableEntityVm(T entity, DataService dataService, Context context)
        {
            Entity = entity;
            DataService = dataService;
            Context = context;
        }

        protected readonly DataService DataService;
        protected readonly Context Context;
    }
}
