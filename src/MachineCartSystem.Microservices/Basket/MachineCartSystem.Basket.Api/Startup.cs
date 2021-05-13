using MachineCartSystem.Basket.Api.Initializer;
using MachineCartSystem.Configuration;
using MachineCartSystem.Entity;
using MachineCartSystem.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MachineCartSystem.BasketApi
{
    public class Startup : PreStartup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env) : base(configuration, env)
        {

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            Initialize<ServiceInitializer>(services);

            //services.AddAutoMapper<MachineCartSystemDbContext, AutoMapperConfig>()
            //.AddController()
            //.AddCustomAuthentication(JwtConfig)
            //.AddCustomAuthorization(JwtConfig)
            //.AddEFCore<MachineCartSystemDbContext>(DbConfig)
            //.AddCustomSwagger(Configuration, JwtConfig)
            //.AddApplicationServices()
            //.AddServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Initialize<MiddlewareInitializer>(app);

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    // app.UseDatabaseErrorPage();
            //} 
            //else if (env.IsProduction())
            //{
            //    app.UseExceptionHandler("/error");
            //    app.UseHsts();
            //}
            //app.UseStaticFiles();

            //app.UseCustomSwagger(Configuration);

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseCors(options =>
            //{
            //    options.AllowAnyOrigin();
            //    options.AllowAnyHeader();
            //    options.AllowAnyMethod();
            //});

            //app.UseAuthentication();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapDefaultControllerRoute();
            //    endpoints.MapControllers();
            //});
        }
    }
}
