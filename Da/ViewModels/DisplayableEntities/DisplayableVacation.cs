using Backend.Entities;
using Da.Services;

namespace Da.ViewModels.DisplayableEntities
{
    class DisplayableVacation: DisplayableEntityVm<Vacation>
    {
        public DisplayableVacation(Vacation entity, EditorService editor) : base(entity, editor)
        {
        }
    }
}
