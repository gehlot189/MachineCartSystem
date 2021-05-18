using Microsoft.AspNetCore.Builder;

namespace MachineCartSystem.Configuration.PreInitializer.Middlewares
{
    public class RoutingMiddleware : PreMiddlewareInitializer
    {
        public override void PreInitialize(IApplicationBuilder app)
        {
            app.UseRouting();
        }
    }
}
