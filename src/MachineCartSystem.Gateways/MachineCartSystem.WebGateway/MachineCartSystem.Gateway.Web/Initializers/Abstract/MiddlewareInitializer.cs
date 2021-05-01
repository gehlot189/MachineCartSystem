using AutoWrapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Ocelot.Middleware;
using System.Net;

namespace MachineCartSystem.Gateway.Web.Initializer
{
    public abstract class MiddlewareInitializer
    {
        public static void Initialize<T>(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration) where T : IApplicationBuilder
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            SwaggerMiddleware.UseSwagger(app, configuration);

            app.UseRouting();

            app.UseHttpsRedirection();

            // app.UseHeaderPropagation();
            app.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions
            {
                IsDebug = env.IsDevelopment(),
                IsApiOnly = false,
                ShouldLogRequestData = true,
                LogRequestDataOnException = true,
                EnableExceptionLogging = true,
                EnableResponseLogging = true,
                UseApiProblemDetailsException = true,
                ShowIsErrorFlagForSuccessfulResponse = true,
            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
                // endpoints.MapControllerRoute("default",pattern: "{controller=Configuration}/{action=Get}",);
                //{
                //    Predicate = _ => true,
                //    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                //});
                //endpoints.MapHealthChecks("/liveness", new HealthCheckOptions
                //{
                //    Predicate = r => r.Name.Contains("self")
                //});
            });

            app.UseOcelot().Wait();
        }
    }
}
