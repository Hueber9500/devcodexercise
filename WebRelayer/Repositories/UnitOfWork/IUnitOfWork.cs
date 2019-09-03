using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRelayer.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}
