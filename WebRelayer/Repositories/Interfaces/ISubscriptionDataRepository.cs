using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRelayer.Entities;

namespace WebRelayer.Repositories
{
    public interface ISubscriptionDataRepository
    {
        Task AddAsync(SubscriptionData element);

        Task AddRangeAsync(IEnumerable<SubscriptionData> elements);

        Task<SubscriptionData> GetByTokenAsync(string token); 
    }
}
