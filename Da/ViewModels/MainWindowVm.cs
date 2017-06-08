using System.Collections.ObjectModel;
using Backend.Entities;
using Da.Services;
using Spectre.Mvvm.Base;

namespace Da.ViewModels
{
    class MainWindowVm: PropertyChangedNotification
    {
        private readonly DataService _dataService;
        private readonly EditorService _editorService;

        public MainWindowVm()
        {
            _dataService = new DataService();
            _editorService = new EditorService(_dataService);
        }

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
                           Employees = new ObservableCollection<Employee>(_dataService.GetData<Employee>());
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

        #region NewProject
        private RelayCommand _newProject;

        public RelayCommand NewProject
        {
            get
            {
                return _newProject ?? (_newProject = new RelayCommand(() =>
                {
                    _editorService.EditNew<Project>();
                }));
            }
        }
        #endregion

        #region NewSalary
        private RelayCommand _newSalary;

        public RelayCommand NewSalary
        {
            get
            {
                return _newSalary ?? (_newSalary = new RelayCommand(() =>
                {
                    _editorService.EditNew<Salary>();
                }));
            }
        }
        #endregion

        #region NewSite
        private RelayCommand _newSite;

        public RelayCommand NewSite
        {
            get
            {
                return _newSite ?? (_newSite = new RelayCommand(() =>
                {
                    _editorService.EditNew<Site>();
                }));
            }
        }
        #endregion

        #region NewVacation
        private RelayCommand _newVacation;

        public RelayCommand NewVacation
        {
            get
            {
                return _newVacation ?? (_newVacation = new RelayCommand(() =>
                {
                    _editorService.EditNew<Vacation>();
                }));
            }
        }
        #endregion
    }
}
