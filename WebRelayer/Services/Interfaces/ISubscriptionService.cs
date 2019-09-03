using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRelayer.DomainModels;
using WebRelayer.DomainModels.Communication;

namespace WebRelayer.Services
{
    public interface ISubscriptionService
    {
        Task<BaseResponse> SubscribeAsync(SubscriptionModel subscriptionModel);
    }
}
