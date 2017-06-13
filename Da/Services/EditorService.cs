using System.Linq;
using System.Windows;
using Backend.Entities;
using Backend.Utils;
using Da.ViewModels.AddEntityVms;

namespace Da.Services
{
    class EditorService
    {
        private readonly DataService _dataService;
        private readonly RefreshingService _refreshingService;

        public EditorService(DataService dataService, RefreshingService refreshingService)
        {
            _dataService = dataService;
            _refreshingService = refreshingService;
        }

        public void Edit<T>(T entity) where T : Entity, new()
        {
            var newEntity = entity == null;
            var id = -1;
            if (entity != null)
            {
                id = entity.GetId(); // @gmrukwa: to not to mix sessions
            }
            using (var context = new Context())
            {
                // @gmrukwa: getting by id to not to mix sessions
                entity = newEntity ? new T() : context.Get<T>(id);
                var vm = EditableEntityVm<T>.GetVm(entity, _dataService, context);
                var window = new AddUpdateWindow(vm) {Owner = App.Current.MainWindow};
                var changesAccepted = window.ShowDialog();
                if (changesAccepted.HasValue && changesAccepted.Value)
                {
                    var dbset = context.Get<T>();
                    if (newEntity)
                        dbset.Add(entity);
                    context.SaveChanges();
                }
            }
            _refreshingService.Refresh();
        }

        public void EditNew<T>() where T : Entity, new()
        {
            Edit<T>(null);
        }

        public void Delete<T>(T entity) where T : Entity, new()
        {
            var id = entity.GetId();
            using (var context = new Context())
            {
                if (typeof(T) == typeof(Employee))
                {
                    foreach (var site in context.Sites.Where(s => s.BossId == id))
                        site.Boss = null;
                    foreach (var project in context.Projects.Where(p => p.ManagerId == id))
                        project.Manager = null;
                }
                if (typeof(T) == typeof(Project))
                {
                    foreach (var salary in context.Salaries.Where(s => s.ProjectId == id))
                        salary.Project = null;
                }
                if (typeof(T) == typeof(Salary))
                {
                    
                }
                if (typeof(T) == typeof(Site))
                {
                    foreach (var employee in context.Employees.Where(e => e.SiteId == id))
                        employee.Site = null;
                }
                if (typeof(T) == typeof(Vacation))
                {
                    
                }
                // @gmrukwa: getting by id to not to mix sessions
                entity = context.Get<T>(id);
                var changesAccepted = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButton.OKCancel);
                if (changesAccepted == MessageBoxResult.OK)
                {
                    var dbset = context.Get<T>();
                    dbset.Remove(entity);
                    context.SaveChanges();
                }
            }
            _refreshingService.Refresh();
        }
    }
}
