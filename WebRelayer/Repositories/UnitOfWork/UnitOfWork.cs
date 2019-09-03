using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRelayer.Database_Contexts;

namespace WebRelayer.Repositories
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly AppCtx _context;

        public UnitOfWork(AppCtx context) => _context = context;

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
