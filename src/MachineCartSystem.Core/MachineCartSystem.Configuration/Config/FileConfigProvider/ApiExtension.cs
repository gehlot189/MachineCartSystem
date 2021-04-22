using MachineCartSystem.Configuration.Config.FileConfigProvider;
using Microsoft.Extensions.Configuration;
using System;

namespace MachineCartSystem.Configuration
{
    public static class ApiExtension
    {
        public static IConfigurationBuilder AddApiConfiguration(this IConfigurationBuilder builder, Action<ApiConfigurationSource> action)
        {
            var source = new ApiConfigurationSource();
            action(source);
            return builder.Add(source);
        }
    }
}
