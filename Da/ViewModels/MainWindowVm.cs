using System.Collections.ObjectModel;
using Backend.Entities;
using Da.Services;
using Spectre.Mvvm.Base;

namespace Da.ViewModels
{
    class MainWindowVm: PropertyChangedNotification
    {
        private readonly EmployeesService _employeesService = new EmployeesService();
        private readonly EditorService _editorService = new EditorService();

        public ObservableCollection<Employee> Employees
        {
            get { return GetValue(() => Employees); }
            set { SetValue(() => Employees, value); }
        }

        #region Refresh
        private RelayCommand _refreshCommand;

        public RelayCommand RefreshCommand
        {
            get
            {
                return _refreshCommand ?? (_refreshCommand = new RelayCommand(() =>
                       {
                           Employees = new ObservableCollection<Employee>(_employeesService.GetEmployees());
                       }));
            }
        }
        #endregion

        #region NewEmployee
        private RelayCommand _newEmployee;

        public RelayCommand NewEmployee
        {
            get
            {
                return _newEmployee ?? (_newEmployee = new RelayCommand(() =>
                       {
                           _editorService.EditNew<Employee>();
                       }));
            }
        }
        #endregion
    }
}
