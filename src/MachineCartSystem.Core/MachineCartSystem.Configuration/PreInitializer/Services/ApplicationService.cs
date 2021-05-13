using MachineCartSystem.Configuration.PolicyMaker;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.Configuration
{
    public class ApplicationService : PreServiceInitializer
    {
        public override void PreInitialize(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IAuthorizationPolicyProvider, PermissionsPolicyProvider>();
            services.AddSingleton<IAuthorizationHandler, PermissionsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, RolesAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, ScopesAuthorizationHandler>();
        }
    }
}
