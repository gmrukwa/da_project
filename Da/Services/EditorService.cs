using Backend.Entities;
using Backend.Utils;
using Da.ViewModels.AddEntityVms;

namespace Da.Services
{
    class EditorService
    {
        private readonly DataService _dataService;

        public EditorService(DataService dataService)
        {
            _dataService = dataService;
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
                var vm = AddEntityVm<T>.GetVm(entity, _dataService);
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
        }

        public void EditNew<T>() where T : Entity, new()
        {
            Edit<T>(null);
        }
    }
}
