using MachineCartSystem.Configuration;
using MachineCartSystem.Gateway.Web.Initializer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.Gateway.Web
{
    public class Startup : BaseStartup
    {
        public Startup(IWebHostEnvironment env,IConfiguration configuration) : base(env)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.InitializeAllServices(Configuration, this.JwtConfig);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.InitializeAllMiddleware(env, Configuration);
        }
    }
}
