using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRelayer.Database_Contexts;

namespace WebRelayer.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppCtx _context;

        public BaseRepository(AppCtx context) => _context = context;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }
    }
}
