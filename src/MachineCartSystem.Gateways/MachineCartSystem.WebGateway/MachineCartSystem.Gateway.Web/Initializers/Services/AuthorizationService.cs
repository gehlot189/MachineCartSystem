using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.Gateway.Web.Initializer
{
    public class AuthorizationService : ServiceInitializer
    {
        public override void Initialize(IServiceCollection services)
        {
            services.AddAuthorization();
        }
    }
}
