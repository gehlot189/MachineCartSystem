using MachineCartSystem.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.IdentityServer.Initializer
{
    public class AutoMapperService : ServiceInitializer
    {
        public override void Initialize(IServiceCollection services)
        {
            services.AddAutoMapper(p => p.AddMaps(typeof(Startup), typeof(BaseMapper)));
        }
    }
}