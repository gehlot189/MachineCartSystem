using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.Configuration
{
    public class AuthorizationService : PreServiceInitializer
    {
        public override void PreInitialize(IServiceCollection services)
        {
            services.AddAuthorization();
        }
    }
}
