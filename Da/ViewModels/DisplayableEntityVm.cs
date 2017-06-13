using Backend.Entities;
using Da.Services;
using Spectre.Mvvm.Base;

namespace Da.ViewModels
{
    class DisplayableEntityVm<T>: PropertyChangedNotification, IDisplayableEntity where T: Entity, new()
    {
        public DisplayableEntityVm(T entity, EditorService editor)
        {
            Entity = entity;
            _editor = editor;
        }

        public object Entity { get { return GetValue(() => Entity); } set { SetValue(() => Entity, value); } }

        private readonly EditorService _editor;

        private RelayCommand _edit;

        public RelayCommand Edit
        {
            get
            {
                return _edit ?? (_edit = new RelayCommand(() =>
                {
                    _editor.Edit(Entity as T);
                }));
            }
        }

        private RelayCommand _delete;

        public RelayCommand Delete
        {
            get
            {
                return _delete ?? (_delete = new RelayCommand(() =>
                {
                    _editor.Delete(Entity as T);
                }));
            }
        }
    }
}
