using System.Collections.ObjectModel;
using Backend.Entities;
using Backend.Utils;
using Da.Services;

namespace Da.ViewModels.AddEntityVms
{
    class EmployeeVm: EditableEntityVm<Employee>
    {
        public ObservableCollection<Site> Sites { get { return GetValue(() => Sites); } set { SetValue(() => Sites, value); } }

        public EmployeeVm(Employee employee, DataService dataService, Context context) : base(employee, dataService, context)
        {
            Sites = new ObservableCollection<Site>(DataService.GetData<Site>(context));
        }
    }
}
