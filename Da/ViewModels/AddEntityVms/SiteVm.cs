using System.Collections.ObjectModel;
using Backend.Entities;
using Backend.Utils;
using Da.Services;

namespace Da.ViewModels.AddEntityVms
{
    class SiteVm: EditableEntityVm<Site>
    {
        public ObservableCollection<Employee> AllEmployees { get { return GetValue(() => AllEmployees); } set { SetValue(() => AllEmployees, value); } }

        public SiteVm(Site site, DataService dataService, Context context) : base(site, dataService, context)
        {
            AllEmployees = new ObservableCollection<Employee>(DataService.GetData<Employee>(context));
        }
    }
}
