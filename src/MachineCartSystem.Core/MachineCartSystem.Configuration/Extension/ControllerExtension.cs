using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace MachineCartSystem.Configuration
{
    public static class ControllerExtension
    {
        public static IServiceCollection AddController(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(p =>
            {
                p.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });
            return services;
        }
    }
}
