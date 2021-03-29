using MachineCartSystem.Configuration.PolicyMaker;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.Configuration
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionsPolicyProvider>();

            services.AddSingleton<IAuthorizationHandler, PermissionsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, RolesAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, ScopesAuthorizationHandler>();

            return services;
        }
    }
}