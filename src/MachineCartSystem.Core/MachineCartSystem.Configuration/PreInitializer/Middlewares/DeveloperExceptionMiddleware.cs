using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MachineCartSystem.Configuration.PreInitializer.Middlewares
{
    public class DeveloperExceptionMiddleware : PreMiddlewareInitializer
    {
        public override void PreInitialize(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}
