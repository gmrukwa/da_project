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
    public class Salary
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalaryId { get; set; }
        public int? ProjectId { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }
        public int? EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public bool Paid { get; set; }
    }
}
