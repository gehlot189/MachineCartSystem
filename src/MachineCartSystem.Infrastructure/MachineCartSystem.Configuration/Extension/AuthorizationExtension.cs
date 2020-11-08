using IdentityModel;
using MachineCartSystem.Common;
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
                p.AddPolicy(Policy.Admin, q =>
                 {
                     q.RequireAuthenticatedUser();
                     q.RequireRole(Role.Admin);
                 });
                p.AddPolicy(Policy.Basic, q =>
                {
                    q.RequireAuthenticatedUser();
                    q.RequireRole(Role.Basic);
                });
            });
            return services;
        }
    }
}
