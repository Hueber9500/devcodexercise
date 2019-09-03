using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebRelayer.WebClientModels
{
    [Serializable]
    [DataContract]
    public class EmployeeArrivalJsonObject
    {
        [DataMember(Name = "first_name")]
        public string Name { get; set; }

        [DataMember(Name = "last_name")]
        public string SurName { get; set; }

        [DataMember(Name = "when")]
        public string When { get; set; }
    }
}
