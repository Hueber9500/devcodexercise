using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebRelayer.Entities
{
    [Table("EmployeeArrival")]
    public class EmployeeArrival
    {
        [Key]
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        public DateTime Arrival { get; set; }

        /*
        public string Token { get; set; }

        [ForeignKey("Token")]
        public SubscriptionData SubscriptionData { get; set; }
        */
    }
}
