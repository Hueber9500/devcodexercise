using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRelayer.SignalRHub;

namespace WebRelayer.Services
{
    public class NotificationService : INotificationService
    {
        private IHubContext<NotificationsHub> _context;

        public NotificationService(IHubContext<NotificationsHub> context)
        {
            _context = context;
        }
        public async Task NotifyAll(string json)
        {
            await _context.Clients.All.SendAsync("Send", json);
        }

        public async Task NotifyClient(string json, string connectionId)
        {
            await _context.Clients.Client(connectionId).SendAsync("Send", json);
        }
    }
}
