using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRelayer.Services
{
    public interface IConnectionStoreService
    {
        bool Add(string token, string connectionId);

        string Get(string token);

        void RemoveEntriesWithConnectionId(string connectionId);
    }
}
