using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using WebRelayer.Database_Contexts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.Extensions.Http;
using WebRelayer.Services;
using WebRelayer.WebClientModels;
using AutoMapper;
using WebRelayer.DependenciesConfigurations;
using WebRelayer.SignalRHub;

namespace WebRelayer
{
    public class Startup
    {

        public static IConfiguration Configuration { get; private set; }

        private IHostingEnvironment _env;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1)
                .AddJsonOptions(o=>
                {
                    if(o.SerializerSettings.ContractResolver != null)
                    {
                        var castedResolver = o.SerializerSettings.ContractResolver
                        as DefaultContractResolver;

                        castedResolver = new CamelCasePropertyNamesContractResolver();
                    }
                });

            var connectionString = Configuration["Storage:connectionString"];
            services.AddDbContext<AppCtx>(o => 
            {
                o.UseSqlServer(connectionString);
                o.EnableSensitiveDataLogging();
            });

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyMethod().AllowAnyHeader()
                    .AllowAnyOrigin().AllowCredentials()
                    .WithExposedHeaders("X-Pagination");
                });
            });

            RepositoriesDependencies.Config(services);
            ServicesDependencies.Config(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseSignalR(routes =>
            {
                routes.MapHub<NotificationsHub>("/monitoring");
            });
            app.UseMvc();
        }
    }
}
