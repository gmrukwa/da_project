using Backend.Entities;
using Da.Services;

namespace Da.ViewModels.DisplayableEntities
{
    class DisplayableSite: DisplayableEntityVm<Site>
    {
        public DisplayableSite(Site entity, EditorService editor) : base(entity, editor)
        {
        }
    }
}
