using Microsoft.AspNetCore.Builder;
using Ocelot.Middleware;

namespace MachineCartSystem.Gateway.Web.Initializer
{
    public class OcelotMiddleware : MiddlewareInitializer
    {
        public override void Initialize(IApplicationBuilder app)
        {
            app.UseOcelot().Wait();
        }
    }
}
