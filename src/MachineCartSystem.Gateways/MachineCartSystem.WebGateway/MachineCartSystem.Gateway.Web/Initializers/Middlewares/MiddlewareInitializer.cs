using AutoWrapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Ocelot.Middleware;

namespace MachineCartSystem.Gateway.Web.Initializer
{
    public static class MiddlewareInitializer
    {
        public static void InitializeAllMiddleware(this IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            SwaggerMiddleware.UseSwagger(app, configuration);

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
                //endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
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
