using Microsoft.AspNetCore.Hosting;
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
                    webBuilder.ConfigureAppConfiguration(p =>
                    {

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
