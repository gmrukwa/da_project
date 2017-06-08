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
    public class Project : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get { return GetValue(() => ProjectId); } set { SetValue(() => ProjectId, value); } }
        public int? ManagerId { get { return GetValue(() => ManagerId); } set { SetValue(() => ManagerId, value); } }
        [ForeignKey(nameof(ManagerId))]
        public Employee Manager { get { return GetValue(() => Manager); } set { SetValue(() => Manager, value); } }
        public DateTime StartDate { get { return GetValue(() => StartDate); } set { SetValue(() => StartDate, value); } }
        public string Name { get { return GetValue(() => Name); } set { SetValue(() => Name, value); } }
        public string Description { get { return GetValue(() => Description); } set { SetValue(() => Description, value); } }
        [InverseProperty(nameof(Project))]
        public List<Salary> Salaries { get { return GetValue(() => Salaries); } set { SetValue(() => Salaries, value); } }
        public override int GetId() => ProjectId;
    }
}
