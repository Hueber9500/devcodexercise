using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRelayer.Services
{
    public interface INotificationService
    {
        Task NotifyClient(string json, string connectionId);

        Task NotifyAll(string json);
    }
}
