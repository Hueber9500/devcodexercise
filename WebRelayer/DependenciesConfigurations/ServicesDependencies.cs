using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRelayer.Services;

namespace WebRelayer.DependenciesConfigurations
{
    public class ServicesDependencies
    {
        public static void Config(IServiceCollection services)
        {
            services.AddScoped<IHttpClient, AlaricMonitorHttpClient>();
            services.AddHttpClient<IHttpClient, AlaricMonitorHttpClient>(); 
            services.AddScoped<ISeedService, SeedService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<IRelayService, RelayService>();
            services.AddSingleton<IConnectionStoreService, ConnectionStoreService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IResourcesService, ResourcesService>();

            services.AddAutoMapper();

            services.AddSignalR();
        }
    }
}
