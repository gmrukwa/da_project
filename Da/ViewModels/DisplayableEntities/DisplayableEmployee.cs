using Backend.Entities;
using Da.Services;

namespace Da.ViewModels.DisplayableEntities
{
    class DisplayableEmployee: DisplayableEntityVm<Employee>
    {
        public DisplayableEmployee(Employee entity, EditorService editor) : base(entity, editor)
        {
        }
    }
}
