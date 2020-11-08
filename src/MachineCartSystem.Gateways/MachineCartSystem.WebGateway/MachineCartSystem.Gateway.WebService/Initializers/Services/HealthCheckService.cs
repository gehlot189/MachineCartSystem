using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.Gateway.WebService.Initializers.Services
{
    public class HealthCheckService
    {
        public static void Initialize<T>(IServiceCollection services) where T : DbContext
        {
            //ToDO :: Need work here
            //  services.AddHealthChecks().AddDbContextCheck<T>();
        }
    }
}
