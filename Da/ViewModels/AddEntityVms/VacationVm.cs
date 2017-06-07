﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Entities;
using Spectre.Mvvm.Base;

namespace Da.ViewModels.AddEntityVms
{
    class VacationVm: PropertyChangedNotification
    {
        public Vacation Vacation { get { return GetValue(() => Vacation); } set { SetValue(() => Vacation, value); } }

        public ObservableCollection<Employee> AllEmployees { get { return GetValue(() => AllEmployees); } set { SetValue(() => AllEmployees, value); } }

        public VacationVm(Vacation vacation)
        {
            Vacation = vacation;
            // @gmrukwa: TODO read available employees
        }
    }
}