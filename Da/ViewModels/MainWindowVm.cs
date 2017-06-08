using System;
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
            RefreshCommand.Execute(null);
        }

        #region Collections
        public ObservableCollection<Employee> Employees
        {
            get { return GetValue(() => Employees); }
            set { SetValue(() => Employees, value); }
        }

        public ObservableCollection<Project> Projects
        {
            get { return GetValue(() => Projects); }
            set { SetValue(() => Projects, value); }
        }

        public ObservableCollection<Salary> Salaries
        {
            get { return GetValue(() => Salaries); }
            set { SetValue(() => Salaries, value); }
        }

        public ObservableCollection<Site> Sites
        {
            get { return GetValue(() => Sites); }
            set { SetValue(() => Sites, value); }
        }

        public ObservableCollection<Vacation> Vacations
        {
            get { return GetValue(() => Vacations); }
            set { SetValue(() => Vacations, value); }
        }
        #endregion

        #region Refresh
        private RelayCommand _refreshCommand;

        public RelayCommand RefreshCommand
        {
            get
            {
                return _refreshCommand ?? (_refreshCommand = new RelayCommand(() =>
                       {
                           _dataService.GetData<Employee>((dbset, ex) =>
                           {
                               if(ex!=null)
                                   throw new InvalidOperationException("Check inner exception", ex);
                               Employees = new ObservableCollection<Employee>(dbset.Include("Site"));
                           });
                           _dataService.GetData<Project>((dbset, ex) =>
                           {
                               if (ex != null)
                                   throw new InvalidOperationException("Check inner exception", ex);
                               Projects = new ObservableCollection<Project>(dbset.Include("Manager"));
                           });
                           _dataService.GetData<Salary>((dbset, ex) =>
                           {
                               if (ex != null)
                                   throw new InvalidOperationException("Check inner exception", ex);
                               Salaries = new ObservableCollection<Salary>(dbset.Include("Employee").Include("Project"));
                           });
                           _dataService.GetData<Site>((dbset, ex) =>
                           {
                               if (ex != null)
                                   throw new InvalidOperationException("Check inner exception", ex);
                               Sites = new ObservableCollection<Site>(dbset.Include("Boss"));
                           });
                           _dataService.GetData<Vacation>((dbset, ex) =>
                           {
                               if (ex != null)
                                   throw new InvalidOperationException("Check inner exception", ex);
                               Vacations = new ObservableCollection<Vacation>(dbset.Include("Employee"));
                           });
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
