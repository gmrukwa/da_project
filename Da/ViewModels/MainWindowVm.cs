using System;
using System.Collections.ObjectModel;
using System.Linq;
using Backend.Entities;
using Da.Services;
using Da.ViewModels.DisplayableEntities;
using Spectre.Mvvm.Base;

namespace Da.ViewModels
{
    class MainWindowVm: PropertyChangedNotification
    {
        private readonly DataService _dataService;
        private readonly EditorService _editorService;
        private readonly RefreshingService _refreshingService;
        private readonly SummaryService _summaryService;

        public MainWindowVm()
        {
            _dataService = new DataService();
            _refreshingService = new RefreshingService(this);
            _editorService = new EditorService(_dataService, _refreshingService);
            _summaryService = new SummaryService();
            RefreshCommand.Execute(null);
        }

        #region Collections
        public ObservableCollection<DisplayableEmployee> Employees
        {
            get { return GetValue(() => Employees); }
            set { SetValue(() => Employees, value); }
        }

        public ObservableCollection<DisplayableProject> Projects
        {
            get { return GetValue(() => Projects); }
            set { SetValue(() => Projects, value); }
        }

        public ObservableCollection<DisplayableSalary> Salaries
        {
            get { return GetValue(() => Salaries); }
            set { SetValue(() => Salaries, value); }
        }

        public ObservableCollection<DisplayableSite> Sites
        {
            get { return GetValue(() => Sites); }
            set { SetValue(() => Sites, value); }
        }

        public ObservableCollection<DisplayableVacation> Vacations
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
                               Employees = new ObservableCollection<DisplayableEmployee>(dbset.Include("Site").ToList().Select(e => new DisplayableEmployee(e, _editorService)));
                           });
                           _dataService.GetData<Project>((dbset, ex) =>
                           {
                               if (ex != null)
                                   throw new InvalidOperationException("Check inner exception", ex);
                               Projects = new ObservableCollection<DisplayableProject>(dbset.Include("Manager").ToList().Select(e => new DisplayableProject(e, _editorService)));
                           });
                           _dataService.GetData<Salary>((dbset, ex) =>
                           {
                               if (ex != null)
                                   throw new InvalidOperationException("Check inner exception", ex);
                               Salaries = new ObservableCollection<DisplayableSalary>(dbset.Include("Project").Include("Employee").ToList().Select(e => new DisplayableSalary(e, _editorService)));
                           });
                           _dataService.GetData<Site>((dbset, ex) =>
                           {
                               if (ex != null)
                                   throw new InvalidOperationException("Check inner exception", ex);
                               Sites = new ObservableCollection<DisplayableSite>(dbset.Include("Boss").ToList().Select(e => new DisplayableSite(e, _editorService)));
                           });
                           _dataService.GetData<Vacation>((dbset, ex) =>
                           {
                               if (ex != null)
                                   throw new InvalidOperationException("Check inner exception", ex);
                               Vacations = new ObservableCollection<DisplayableVacation>(dbset.Include("Employee").ToList().Select(e => new DisplayableVacation(e, _editorService)));
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

        #region SummarizePayoffs
        private RelayCommand _summarizePayoffs;

        public RelayCommand SummarizePayoffs
        {
            get
            {
                return _summarizePayoffs ?? (_summarizePayoffs =
                           new RelayCommand(() => _summaryService.CountPayoffs()));
            }
        }
        #endregion
    }
}
