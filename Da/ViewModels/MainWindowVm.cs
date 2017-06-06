using System.Collections.ObjectModel;
using Backend.Entities;
using Da.Services;
using Spectre.Mvvm.Base;

namespace Da.ViewModels
{
    class MainWindowVm: PropertyChangedNotification
    {
        readonly EmployeesService _employeesService = new EmployeesService();

        public ObservableCollection<Employee> Employees
        {
            get { return GetValue(() => Employees); }
            set { SetValue(() => Employees, value); }
        }

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
    }
}
