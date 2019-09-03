using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebRelayer.Entities
{
    [Table("EmployeeTeam")]
    public class EmployeeTeam
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
