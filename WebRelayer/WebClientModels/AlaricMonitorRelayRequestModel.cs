using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRelayer.WebClientModels
{
    public class AlaricMonitorRelayRequestModel
    {
        public int EmployeeId { get; set; }

        /// <summary>
        /// ISO 8601 format
        /// </summary>
        public string When { get; set; }
    }
}
