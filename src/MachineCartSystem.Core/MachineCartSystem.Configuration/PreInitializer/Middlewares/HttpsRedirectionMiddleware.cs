using Microsoft.AspNetCore.Builder;

namespace MachineCartSystem.Configuration.PreInitializer.Middlewares
{
    public class HttpsRedirectionMiddleware : PreMiddlewareInitializer
    {
        public override void PreInitialize(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
        }
    }
}
