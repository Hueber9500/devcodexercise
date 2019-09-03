using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRelayer.DomainModels
{
    public class SubscriptionModel
    {
        public string CallbackUrl { get; set; }

        public DateTime ShortDate { get; set; }

        public string SignalRConnectionId { get; set; }
    }
}
