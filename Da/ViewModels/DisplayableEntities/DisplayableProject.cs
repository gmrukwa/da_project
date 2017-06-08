using Backend.Entities;
using Da.Services;

namespace Da.ViewModels.DisplayableEntities
{
    class DisplayableProject:DisplayableEntityVm<Project>
    {
        public DisplayableProject(Project entity, EditorService editor) : base(entity, editor)
        {
        }
    }
}
