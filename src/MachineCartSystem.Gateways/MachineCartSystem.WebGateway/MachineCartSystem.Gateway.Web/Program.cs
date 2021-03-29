using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MMLib.SwaggerForOcelot.DependencyInjection;
using Serilog;
using System.IO;
using System.Linq;
using MachineCartSystem.Gateway.WebService.Resolver;

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
                        p.SetBasePath(q.HostingEnvironment.ContentRootPath);

                        p.AddOcelotWithSwaggerSupport(q.HostingEnvironment, "Configuration", "ocelot.swagger");
                        p.AddJsonFile("ocelot.json", false, true);

                        p.AddJsonFile("appsettings.json", false, true);
                        p.AddJsonFile($"appsettings.{q.HostingEnvironment.EnvironmentName}.json", false, true);

                        p.AddJsonFile("appUrl.json", false, true);
                        p.AddJsonFile($"appUrl.{q.HostingEnvironment.EnvironmentName}.json", false, true);

                        var identityFile = JsonResolver.ResolveIdentityConfigurationSetting(q.HostingEnvironment);
                        p.AddJsonFile(identityFile, false, true);

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
