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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }
        public int? ManagerId { get; set; }
        [ForeignKey(nameof(ManagerId))]
        public Employee Manager { get; set; }
        public DateTime StartDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [InverseProperty(nameof(Project))]
        public List<Salary> Salaries { get; set; }
    }
}
