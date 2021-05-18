using Microsoft.AspNetCore.Builder;

namespace MachineCartSystem.Configuration.PreInitializer.Middlewares
{
    public class AuthenticationMiddleware : PreMiddlewareInitializer
    {
        public override void PreInitialize(IApplicationBuilder app)
        {
            app.UseAuthentication();
        }   
    }
}
