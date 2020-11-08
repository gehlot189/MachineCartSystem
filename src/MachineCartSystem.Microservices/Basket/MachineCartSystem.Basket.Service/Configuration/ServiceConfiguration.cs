using MachineCartSystem.Service.Interfaces;
using MachineCartSystem.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.Service
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}
