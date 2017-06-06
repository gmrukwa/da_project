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
    public class Vacation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VacationId { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
        public DateTime BeginningDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
