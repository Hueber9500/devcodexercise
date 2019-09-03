using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebRelayer.WebClientModels
{
    [DataContract]
    [Serializable]
    public class AlaricMonitorResponseModel
    {
        [DataMember(Name = "Token")]
        public string Token { get; set; }

        [DataMember(Name = "expires")]
        public string ExpirationDate { get; set; }
    }
}
