using AutoWrapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MachineCartSystem.Configuration.PreInitializer.Middlewares
{
    public class ApiResponseMiddleware : PreMiddlewareInitializer
    {
        public override void PreInitialize(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
        }
    }
}
