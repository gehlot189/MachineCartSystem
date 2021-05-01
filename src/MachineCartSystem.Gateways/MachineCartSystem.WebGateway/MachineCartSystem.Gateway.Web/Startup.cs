using MachineCartSystem.Configuration;
using MachineCartSystem.Gateway.Web.Initializer;
using MachineCartSystem.Gateway.WebService.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.Gateway.Web
{
    public class Startup : BaseStartup
    {
        public Startup(IConfiguration configuration) : base(configuration, ApiName.Gateway)
        {
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ServiceInitializer.Initialize<IServiceCollection>(services, Configuration, JwtConfig);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfigurationService configurationService)
        {
            MiddlewareInitializer.Initialize<IApplicationBuilder>(app, env, Configuration);
            configurationService.RefreshGatewayConfiguration();
        }
    }
}
