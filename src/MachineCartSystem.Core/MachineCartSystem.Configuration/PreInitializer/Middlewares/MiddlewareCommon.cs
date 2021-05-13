using AutoWrapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace MachineCartSystem.Configuration
{
    public class MiddlewareCommon : PreMiddlewareInitializer
    {
        public override void PreInitialize(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            //SwaggerMiddleware.UseSwagger(app, configuration);

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

            if (configuration.GetSection("Name").Value != ApiName.Gateway.ToString())
            {
                app.UseSwagger();
                app.UseSwaggerUI(p =>
                {
                    p.InjectStylesheet("/swagger-ui/custom.css");
                    p.SwaggerEndpoint("/swagger/v1/swagger.json", configuration.GetSection("Name").Value);
                    p.EnableDeepLinking();

                    if (configuration.GetSection("Name").Value != ApiName.Identity.ToString())
                    {
                        p.OAuthClientId("angular");
                        p.OAuthUsePkce();
                        p.OAuth2RedirectUrl($"{configuration.GetSection("Url").Value }swagger/oauth2-redirect.html");
                    }
                });
            }

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


            
        }

    }
}
