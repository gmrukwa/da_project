using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Entities;
using Spectre.Mvvm.Base;

namespace Da.ViewModels.AddEntityVms
{
    class SiteVm: AddEntityVm<Site>
    {
        public Site Site { get { return GetValue(() => Site); } set { SetValue(() => Site, value); } }

        public ObservableCollection<Employee> AllEmployees { get { return GetValue(() => AllEmployees); } set { SetValue(() => AllEmployees, value); } }

        public SiteVm(Site site)
        {
            Site = site;
            AllEmployees = new ObservableCollection<Employee>();
            // @gmrukwa: TODO read existing employees
        }
    }
}
