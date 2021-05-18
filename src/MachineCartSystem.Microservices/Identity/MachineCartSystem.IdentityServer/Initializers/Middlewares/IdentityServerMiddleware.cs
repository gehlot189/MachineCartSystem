using Microsoft.AspNetCore.Builder;

namespace MachineCartSystem.IdentityServer.Initializer
{
    public class IdentityServerMiddleware : MiddlewareInitializer
    {
        public override void Initialize(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Content-Security-Policy", "script-src 'self' 'unsafe-inline';style-src 'self' 'unsafe-inline';img-src 'self' data:;font-src 'self';frame-ancestors 'self' http://localhost:2000;block-all-mixed-content");
                await next();
            });
            app.UseIdentityServer();
        }
    }
}
