﻿using System.Collections.ObjectModel;
using Backend.Entities;
using Backend.Utils;
using Da.Services;

namespace Da.ViewModels.AddEntityVms
{
    class VacationVm: EditableEntityVm<Vacation>
    {
        public ObservableCollection<Employee> AllEmployees { get { return GetValue(() => AllEmployees); } set { SetValue(() => AllEmployees, value); } }

        public VacationVm(Vacation vacation, DataService dataService, Context context) : base(vacation, dataService, context)
        {
            AllEmployees = new ObservableCollection<Employee>(DataService.GetData<Employee>(context));
        }
    }
}
