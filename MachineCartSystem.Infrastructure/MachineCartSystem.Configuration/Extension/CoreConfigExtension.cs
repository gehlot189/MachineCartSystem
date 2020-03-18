using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.Configuration
{
    public static class CoreConfigExtension
    {
        public static void AddCors(this IServiceCollection services)
        {
            services.AddCors();
        }
    }
}
