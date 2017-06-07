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
    class ProjectVm: PropertyChangedNotification
    {
        public Project Project { get { return GetValue(() => Project); } set { SetValue(() => Project, value); } }
        
        public ObservableCollection<Employee> AllEmployees { get { return GetValue(() => AllEmployees); } set { SetValue(() => AllEmployees, value); } }

        public ProjectVm(Project project)
        {
            Project = project;
            //@gmrukwa: TODO: Read all employees
        }
    }
}
