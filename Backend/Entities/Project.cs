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
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [ForeignKey(nameof(Manager))]
        public int ManagerId { get; set; }
        public Employee Manager { get; set; }
        public DateTime StartDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
