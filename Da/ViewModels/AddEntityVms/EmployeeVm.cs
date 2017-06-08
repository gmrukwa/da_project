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
    class EmployeeVm: AddEntityVm<Employee>
    {
        public Employee Employee { get { return GetValue(() => Employee); } set { SetValue(() => Employee, value); } }
        public ObservableCollection<Site> Sites { get { return GetValue(() => Sites); } set { SetValue(() => Sites, value); } }

        public EmployeeVm(Employee employee)
        {
            Employee = employee;
            Sites = new ObservableCollection<Site>();
            // @gmrukwa: TODO: read all existing sites
        }
    }
}
