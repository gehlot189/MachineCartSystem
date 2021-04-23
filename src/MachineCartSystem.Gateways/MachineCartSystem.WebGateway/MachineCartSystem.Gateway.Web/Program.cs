using MachineCartSystem.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MMLib.SwaggerForOcelot.DependencyInjection;
using Serilog;

namespace MachineCartSystem.Gateway.Web
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
                      //  p.Sources.Clear();

                     //   p.SetBasePath(q.HostingEnvironment.ContentRootPath);

                        p.AddOcelotWithSwaggerSupport(q.HostingEnvironment, "OcelotConfiguration", "ocelot.swagger");
                        p.AddJsonFile("ocelot.json", false, true);

                        //p.AddJsonFile("app-url.json", false, true);
                        //p.AddJsonFile($"app-url.{q.HostingEnvironment.EnvironmentName}.json", false, true);

                        p.AddJsonFile($"appsettings.{q.HostingEnvironment.EnvironmentName}.json", false, true);

                        p.AddJsonFile($"global.{q.HostingEnvironment.EnvironmentName}.json", false, true);

                        p.AddEnvironmentVariables();
                    });
                    webBuilder.UseSerilog((p, q) =>
                                {
                                    q.MinimumLevel.Debug()
                                    .Enrich.FromLogContext()
                                    .WriteTo.Console();
                                });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
