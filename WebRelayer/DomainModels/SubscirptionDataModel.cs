using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRelayer.DomainModels
{
    public class SubscirptionDataModel
    {
        public string Token { get; set; }

        public DateTime ValidTo { get; set; }
    }
}
