
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using WebRelayer.Services;

namespace WebRelayer.SignalRHub
{
    public class NotificationsHub:Hub<INotificationClient>
    {
        public async Task Send(string json) => await Clients.All.Send(json);
        
    }
}
