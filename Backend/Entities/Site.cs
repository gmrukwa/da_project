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
        [Key]
        public int SiteId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(Boss))]
        public int BossId { get; set; }
        public Employee Boss { get; set; }
    }
}
