using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRelayer.Repositories;

namespace WebRelayer.DependenciesConfigurations
{
    public static class RepositoriesDependencies
    {
        public static void Config(IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ISubscriptionDataRepository, SubscriptionDataRepository>();
            services.AddScoped<IEmployeeArrivalRepository, EmployeeArrivalRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
