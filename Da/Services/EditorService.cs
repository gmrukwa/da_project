using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.Utils;
using Da.ViewModels.AddEntityVms;

namespace Da.Services
{
    class EditorService
    {
        public void Edit<T>(T entity) where T : Entity, new()
        {
            var id = -1;
            if (entity != null)
            {
                id = entity.GetId(); // @gmrukwa: to not to mix sessions
            }
            using (var context = new Context())
            {
                // @gmrukwa: getting by id to not to mix sessions
                entity = entity != null ? context.Get<T>(id) : new T(); 
                var vm = AddEntityVm<T>.GetVm(entity);
                var window = new AddUpdateWindow(vm) {Owner = App.Current.MainWindow};
                var changesAccepted = window.ShowDialog();
                if (changesAccepted.HasValue && changesAccepted.Value)
                {
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
