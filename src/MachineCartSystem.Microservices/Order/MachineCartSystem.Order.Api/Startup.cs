using MachineCartSystem.Configuration;
using MachineCartSystem.Order.Api.Initializer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.Order.Api
{
    public class Startup : PreStartup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env) : base(configuration, env)
        {

        }

        public void ConfigureServices(IServiceCollection services)
        {
            Initialize<ServiceInitializer>(services);

            //services
            //.AddAutoMapper<MachineCartSystemDbContext, AutoMapperConfig>()
            //.AddController()
            //.AddCustomAuthentication(JwtConfig)
            //.AddCustomAuthorization(JwtConfig)
            ////.AddEFCore<MachineCartSystemDbContext>(DbConfig)
            //.AddCustomSwagger(Configuration, JwtConfig)
            //.AddApplicationServices();
            //  .AddServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Initialize<MiddlewareInitializer>(app);
        }
    }
}
