using MachineCartSystem.Configuration;
using MachineCartSystem.Gateway.Web.Initializer;
using MachineCartSystem.Gateway.WebService.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.Gateway.Web
{
    public class Startup : PreStartup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env) : base(configuration, env,ApiName.Gateway)
        {
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Initialize<ServiceInitializer>(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfigurationService configurationService)
        {
            configurationService.RefreshGatewayConfiguration();

            Initialize<MiddlewareInitializer>(app);

            //MiddlewareInitializer.Initialize<IApplicationBuilder>(app, env, Configuration);
        }
    }
}
