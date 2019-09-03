using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRelayer.DomainModels;
using WebRelayer.DomainModels.Communication;

namespace WebRelayer.Services
{
    public interface IRelayService
    {
        Task<BaseResponse> RelayAsync(IEnumerable<EmployeeArrivalInformationModel> data, string token);
    }
}
