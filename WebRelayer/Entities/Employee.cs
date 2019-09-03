using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebRelayer.Entities
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string Surname { get; set; }

        //public string Email { get; set; }
        
        public int Age { get; set; }
        
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        
        public Nullable<int> ManagerId { get; set; }

        [ForeignKey("ManagerId")]
        public Employee Manager { get; set; }

        public ICollection<EmployeeTeam> Teams { get; set; }
    }
}
