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
    public class Employee: Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get { return GetValue(() => EmployeeId); } set { SetValue(() => EmployeeId, value); } }
        public string Name { get { return GetValue(() => Name); } set { SetValue(() => Name, value); } }
        public string Position { get { return GetValue(() => Position); } set { SetValue(() => Position, value); } }
        public DateTime BirthDate { get { return GetValue(() => BirthDate); } set { SetValue(() => BirthDate, value); } }
        public DateTime EmploymentDate { get { return GetValue(() => EmploymentDate); } set { SetValue(() => EmploymentDate, value); } }
        public int SiteId { get { return GetValue(() => SiteId); } set { SetValue(() => SiteId, value); } }
        [ForeignKey(nameof(SiteId))]
        public virtual Site Site { get { return GetValue(() => Site); } set { SetValue(() => Site, value); } }
        [InverseProperty("Manager")]
        public List<Project> ManagedProjects { get { return GetValue(() => ManagedProjects); } set { SetValue(() => ManagedProjects, value); } }
        [InverseProperty("Boss")]
        public List<Site> ManagedSites { get { return GetValue(() => ManagedSites); } set { SetValue(() => ManagedSites, value); } }
        [InverseProperty("Employee")]
        public List<Salary> Salaries { get { return GetValue(() => Salaries); } set { SetValue(() => Salaries, value); } }
        public override int GetId() => EmployeeId;
    }
}
