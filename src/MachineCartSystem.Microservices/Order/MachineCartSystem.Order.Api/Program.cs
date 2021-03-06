using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MachineCartSystem.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace MachineCartSystem.Order.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((q, p) =>
                    {
                        p.SetBasePath(q.HostingEnvironment.ContentRootPath);
                        p.AddJsonFile($"appsettings.{q.HostingEnvironment.EnvironmentName}.json", false, true);
                        ApiConfigurationProvider.Add(p, q.HostingEnvironment, ApiName.Order);
                    });

                    webBuilder.UseSerilog((p, q) =>
                    {
                        q.MinimumLevel.Information()
                        .Enrich.FromLogContext()
                        .WriteTo.Console();
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
