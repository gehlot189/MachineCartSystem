using MachineCartSystem.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace MachineCartSystem.Configuration
{
    public static class AuthorizationExtension
    {
        public static IServiceCollection AddCustomAuthorization(this IServiceCollection services, JwtConfig jwtConfig,
            IEnumerable<PolicyApplier> policyAppliers = null)
        {
            services.AddAuthorization(p =>
            {
                //policyAppliers?.ToList().ForEach(q =>
                //{
                //    p.AddPolicy(q.PoliyName, r =>
                //     {
                //         if (q.IsRequireAuthenticatedUser)
                //             r.RequireAuthenticatedUser();
                //         r.AddRequirements(q.AuthorizationRequirements);
                //     });
                //});

                //p.AddPolicy(Policy.Minimum, q =>
                // {
                //     q.RequireAuthenticatedUser();
                //     q.(new MinimumRequiredPolicyHandler());
                // });
                //p.AddPolicy(Policy.Admin, q =>
                //{
                //    q.RequireAuthenticatedUser();
                //    //q.RequireRole(Role.buisness_head);
                //});
            });

            return services;
        }
    }
}
