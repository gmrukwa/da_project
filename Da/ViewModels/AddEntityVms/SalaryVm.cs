using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Entities;
using Spectre.Mvvm.Base;

namespace Da.ViewModels.AddEntityVms
{
    class SalaryVm: AddEntityVm<Salary>
    {
        public Salary Salary { get { return GetValue(() => Salary); } set { SetValue(() => Salary, value);} }

        public ObservableCollection<Project> AllProjects { get { return GetValue(() => AllProjects); } set { SetValue(() => AllProjects, value);} }
        public ObservableCollection<Salary> AllSalaries { get { return GetValue(() => AllSalaries); } set { SetValue(() => AllSalaries, value); } }

        public SalaryVm(Salary salary)
        {
            Salary = salary;
            AllSalaries = new ObservableCollection<Salary>();
            AllProjects = new ObservableCollection<Project>();
            // @gmrukwa: TODO: read all other entities.
        }
    }
}
