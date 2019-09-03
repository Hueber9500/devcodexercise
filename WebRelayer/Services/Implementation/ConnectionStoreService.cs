using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRelayer.Services
{
    public class ConnectionStoreService : IConnectionStoreService
    {
        private readonly ConcurrentDictionary<string, string> _store;

        public ConnectionStoreService()
        {
            _store = new ConcurrentDictionary<string, string>();
        }

        public bool Add(string token, string connectionId)
        {
            return _store.TryAdd(token, connectionId);
        }

        public string Get(string token)
        {
            string connectionId;
            bool isSuccess = _store.TryGetValue(token, out connectionId);

            return isSuccess ? connectionId : string.Empty;
        }

        public void RemoveEntriesWithConnectionId(string connectionId)
        {
            var itemsToRemove = _store.Where(kv => kv.Value == connectionId);
            foreach(var item in itemsToRemove)
            {
                _store.TryRemove(item.Key, out string val);
            }
        }
    }
}
