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
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EmploymentDate { get; set; }
        public int SiteId { get; set; }
        [ForeignKey(nameof(SiteId))]
        public virtual Site Site { get; set; }
        [InverseProperty("Manager")]
        public List<Project> ManagedProjects { get; set; }
        [InverseProperty("Boss")]
        public List<Site> ManagesSites { get; set; }
        [InverseProperty("Employee")]
        public List<Salary> Salaries { get; set; }
    }
}
