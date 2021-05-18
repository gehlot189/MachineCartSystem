using Microsoft.AspNetCore.Builder;

namespace MachineCartSystem.Configuration.PreInitializer.Middlewares
{
    public class CoreMiddleware : PreMiddlewareInitializer
    {
        public override void PreInitialize(IApplicationBuilder app)
        {
            app.UseCors("CorsPolicy");
        }
    }
}
