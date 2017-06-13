using System.Collections.ObjectModel;
using Backend.Entities;
using Backend.Utils;
using Da.Services;

namespace Da.ViewModels.AddEntityVms
{
    class SalaryVm: EditableEntityVm<Salary>
    {
        public ObservableCollection<Project> AllProjects { get { return GetValue(() => AllProjects); } set { SetValue(() => AllProjects, value);} }
        public ObservableCollection<Employee> AllEmployees { get { return GetValue(() => AllEmployees); } set { SetValue(() => AllEmployees, value); } }

        public SalaryVm(Salary salary, DataService dataService, Context context) : base(salary, dataService, context)
        {
            AllEmployees = new ObservableCollection<Employee>(DataService.GetData<Employee>(context));
            AllProjects = new ObservableCollection<Project>(DataService.GetData<Project>(context));
        }
    }
}
