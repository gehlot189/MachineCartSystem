using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.Configuration
{
    public static class HeathExtension
    {
        public static void AddHealthChecks<T>(this IServiceCollection services) where T : DbContext
        {
            //ToDO :: Need work here
            services.AddHealthChecks().AddDbContextCheck<T>();
        }
    }
}
