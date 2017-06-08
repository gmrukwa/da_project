using System.Collections.ObjectModel;
using Backend.Entities;
using Da.Services;

namespace Da.ViewModels.AddEntityVms
{
    class SiteVm: EditableEntityVm<Site>
    {
        public ObservableCollection<Employee> AllEmployees { get { return GetValue(() => AllEmployees); } set { SetValue(() => AllEmployees, value); } }

        public SiteVm(Site site, DataService dataService) : base(site, dataService)
        {
            AllEmployees = new ObservableCollection<Employee>(DataService.GetData<Employee>());
        }
    }
}
