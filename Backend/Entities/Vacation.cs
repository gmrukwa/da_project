using System;
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
    public class Vacation : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VacationId { get { return GetValue(() => VacationId); } set { SetValue(() => VacationId, value); } }
        public int EmployeeId { get { return GetValue(() => EmployeeId); } set { SetValue(() => EmployeeId, value); } }
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get { return GetValue(() => Employee); } set { SetValue(() => Employee, value); } }
        public DateTime BeginningDate { get { return GetValue(() => BeginningDate); } set { SetValue(() => BeginningDate, value); } }
        public DateTime EndDate { get { return GetValue(() => EndDate); } set { SetValue(() => EndDate, value); } }

        public override int GetId() => VacationId;
    }
}
