using MachineCartSystem.Basket.Service;
using MachineCartSystem.Configuration;
using MachineCartSystem.Configuration.Config.FileConfigProvider;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;


namespace MachineCartSystem.BasketApi
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
                        AppSettingProvider.Add(p, q.HostingEnvironment);
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
