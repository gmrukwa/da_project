using Backend.Entities;
using Da.Services;

namespace Da.ViewModels.DisplayableEntities
{
    class DisplayableSalary: DisplayableEntityVm<Salary>
    {
        public DisplayableSalary(Salary entity, EditorService editor) : base(entity, editor)
        {
        }
    }
}
