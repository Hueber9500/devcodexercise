using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebRelayer.Entities
{
    [Table("SubscriptionData")]
    public class SubscriptionData
    {
        [Required]
        [Key]
        public string Token { get; set; }

        [Required]
        public DateTime ValidTo { get; set; }
        
    }
}
