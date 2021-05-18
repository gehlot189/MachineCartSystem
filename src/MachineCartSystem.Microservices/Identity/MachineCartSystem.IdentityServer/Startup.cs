using MachineCartSystem.Configuration;
using MachineCartSystem.IdentityServer.Initializer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.IdentityServer
{
    public class Startup : PreStartup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env) : base(configuration, env)
        {
            //Revocation Endpoint
            //End Session Endpoint
            //logout
            //multiple session 
            //force to logout from all
            //revoke on request
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //const string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;database=IdentityServer4.Quickstart.EntityFramework-2.0.0;trusted_connection=yes;";
            //var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            Initialize<ServiceInitializer>(services);
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
            //  app.UseCors("AllowOrigin");
            //app.UseCors(options =>
            //{
            //    options.AllowAnyOrigin();
            //    options.AllowAnyHeader();
            //    options.AllowAnyMethod();
            //});
            //app.Use(async (context, next) =>
            //{
            //    context.Response.Headers.Add("Content-Security-Policy", "script-src 'self' 'unsafe-inline';style-src 'self' 'unsafe-inline';img-src 'self' data:;font-src 'self';frame-ancestors 'self' http://localhost:2000;block-all-mixed-content");
            //    await next();
            //});
            //app.UseStaticFiles();
            //app.UseCustomSwagger(Configuration);
            //app.UseRouting();
            //app.UseIdentityServer();
            //app.UseAuthentication();
            //app.UseAuthorization();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapDefaultControllerRoute();
            //});
        }
    }
}
