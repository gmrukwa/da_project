using System.Collections.ObjectModel;
using Backend.Entities;
using Da.Services;

namespace Da.ViewModels.AddEntityVms
{
    class ProjectVm: EditableEntityVm<Project>
    {
        public ObservableCollection<Employee> AllEmployees { get { return GetValue(() => AllEmployees); } set { SetValue(() => AllEmployees, value); } }

        public ProjectVm(Project project, DataService dataService) : base(project, dataService)
        {
            AllEmployees = new ObservableCollection<Employee>(DataService.GetData<Employee>());
        }
    }
}
