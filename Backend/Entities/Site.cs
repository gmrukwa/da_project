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
    public class Site : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SiteId { get { return GetValue(() => SiteId); } set { SetValue(() => SiteId, value); } }
        public string Address { get { return GetValue(() => Address); } set { SetValue(() => Address, value); } }
        public string Name { get { return GetValue(() => Name); } set { SetValue(() => Name, value); } }
        public int? BossId { get { return GetValue(() => BossId); } set { SetValue(() => BossId, value); } }
        [ForeignKey(nameof(BossId))]
        public Employee Boss { get { return GetValue(() => Boss); } set { SetValue(() => Boss, value); } }
        [InverseProperty(nameof(Site))]
        public List<Employee> Employees { get { return GetValue(() => Employees); } set { SetValue(() => Employees, value); } }
        public override int GetId() => SiteId;
    }
}
