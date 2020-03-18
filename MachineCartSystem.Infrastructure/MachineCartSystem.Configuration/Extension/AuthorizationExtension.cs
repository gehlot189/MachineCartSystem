using IdentityModel;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace MachineCartSystem.Configuration
{
    public static class AuthorizationExtension
    {
        public static IServiceCollection AddCustomAuthorization(this IServiceCollection services, JwtConfig jwtConfig)
        {
            services.AddAuthorization(p =>
            {
                p.AddPolicy("AdminPolicy", q =>
                 {
                     q.RequireAuthenticatedUser();
                     q.RequireRole("Admin");
                 });
                p.AddPolicy("BasicPolicy", q =>
                {
                    q.RequireAuthenticatedUser();
                    q.RequireRole("Basic");
                });
            });
            return services;
        }
    }
}
