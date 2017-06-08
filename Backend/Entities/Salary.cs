﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Utils;
using Spectre.Mvvm.Base;

namespace Backend.Entities
{
    public class Salary : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalaryId { get { return GetValue(() => SalaryId); } set { SetValue(() => SalaryId, value); } }
        public int? ProjectId { get { return GetValue(() => ProjectId); } set { SetValue(() => ProjectId, value); } }
        [ForeignKey(nameof(ProjectId))]
        public Project Project { get { return GetValue(() => Project); } set { SetValue(() => Project, value); } }
        public int? EmployeeId { get { return GetValue(() => EmployeeId); } set { SetValue(() => EmployeeId, value); } }
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get { return GetValue(() => Employee); } set { SetValue(() => Employee, value); } }
        public double Amount { get { return GetValue(() => Amount); } set { SetValue(() => Amount, value); } }
        public DateTime Date { get { return GetValue(() => Date); } set { SetValue(() => Date, value); } }
        public bool Paid { get { return GetValue(() => Paid); } set { SetValue(() => Paid, value); } }
        public override int GetId() => SalaryId;
    }
}
