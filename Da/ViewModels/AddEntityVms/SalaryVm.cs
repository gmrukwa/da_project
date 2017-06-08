using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Entities;
using Da.Services;
using Spectre.Mvvm.Base;

namespace Da.ViewModels.AddEntityVms
{
    class SalaryVm: AddEntityVm<Salary>
    {
        public Salary Salary { get { return GetValue(() => Salary); } set { SetValue(() => Salary, value);} }

        public ObservableCollection<Project> AllProjects { get { return GetValue(() => AllProjects); } set { SetValue(() => AllProjects, value);} }
        public ObservableCollection<Employee> AllEmployees { get { return GetValue(() => AllEmployees); } set { SetValue(() => AllEmployees, value); } }

        public SalaryVm(Salary salary, DataService dataService) : base(dataService)
        {
            Salary = salary;
            AllEmployees = new ObservableCollection<Employee>(DataService.GetData<Employee>());
            AllProjects = new ObservableCollection<Project>(DataService.GetData<Project>());
        }
    }
}
