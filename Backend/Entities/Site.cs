using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Utils;

namespace Backend.Entities
{
    public class Site
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SiteId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public int? BossId { get; set; }
        [ForeignKey(nameof(BossId))]
        public Employee Boss { get; set; }
        [InverseProperty(nameof(Site))]
        public List<Employee> Employees { get; set; }
    }
}
