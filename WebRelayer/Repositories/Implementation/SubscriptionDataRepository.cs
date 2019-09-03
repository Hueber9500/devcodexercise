using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRelayer.Database_Contexts;
using WebRelayer.Entities;

namespace WebRelayer.Repositories
{
    public class SubscriptionDataRepository :BaseRepository, ISubscriptionDataRepository
    {
        public SubscriptionDataRepository(AppCtx context)
            :base(context)
        {
        }

        public async Task AddAsync(SubscriptionData element) 
            => await _context.SubscriptionsData.AddAsync(element);


        public async Task AddRangeAsync(IEnumerable<SubscriptionData> elements) 
            => await _context.SubscriptionsData.AddRangeAsync(elements);

        public async Task<SubscriptionData> GetByTokenAsync(string token) 
            => await _context.SubscriptionsData
            .Where(sd => sd.Token == token)
            .FirstOrDefaultAsync();
    }
}
