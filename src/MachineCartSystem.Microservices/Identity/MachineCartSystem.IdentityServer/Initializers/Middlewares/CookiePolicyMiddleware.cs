using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MachineCartSystem.IdentityServer.Initializer
{
    public class CookiePolicyMiddleware : MiddlewareInitializer
    {
        public override void Initialize(IApplicationBuilder app)
        {
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.Always,
                MinimumSameSitePolicy = SameSiteMode.Lax
            });
        }
    }
}
