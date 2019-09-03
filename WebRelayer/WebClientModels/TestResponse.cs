using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebRelayer.WebClientModels
{
    [DataContract]
    [Serializable]
    public class TestResponse
    {
        [DataMember(Name = "userId")]
        public string userId { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }
    }
}
