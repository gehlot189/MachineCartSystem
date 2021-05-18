using Microsoft.AspNetCore.Builder;

namespace MachineCartSystem.Configuration.PreInitializer.Middlewares
{
    public class EndpointsMiddleware : PreMiddlewareInitializer
    {
        public override void PreInitialize(IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });
        }
    }
}
