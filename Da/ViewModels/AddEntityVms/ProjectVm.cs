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
    class ProjectVm: AddEntityVm<Project>
    {
        public Project Project { get { return GetValue(() => Project); } set { SetValue(() => Project, value); } }
        
        public ObservableCollection<Employee> AllEmployees { get { return GetValue(() => AllEmployees); } set { SetValue(() => AllEmployees, value); } }

        public ProjectVm(Project project, DataService dataService) : base(dataService)
        {
            Project = project;
            AllEmployees = new ObservableCollection<Employee>(DataService.GetData<Employee>());
        }
    }
}
