using System;
using System.IO;
using AutoMapper;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebRelayer.Database_Contexts;
using WebRelayer.DomainModels;
using WebRelayer.Entities;
using WebRelayer.Services;

namespace WebRelayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var db = scope.ServiceProvider.GetService<AppCtx>();
                    //db.Database.EnsureDeleted();


                    if (db.Database.EnsureCreated())
                    {
                        string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).ToString(), "Data\\employees.json");
                        SeedService seed = new SeedService();
                        seed.Seed(filePath, db);
                    }
                }
                catch(Exception ex)
                {
                    var logger = scope.ServiceProvider.GetService<ILogger<Program>>();
                    logger.LogError(ex, "Error when creating db");
                }
            }
            
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseUrls("http://*:5920")
                .UseStartup<Startup>()
            .ConfigureLogging(logging =>
           {
               logging.ClearProviders();
               logging.AddConsole();
           });
    }
}
