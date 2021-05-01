using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace MachineCartSystem.Configuration
{
    public class ApiConfigurationProvider
    {
        public static void Add(IConfigurationBuilder builder, IWebHostEnvironment hostingEnvironment, ApiName apiName, bool optional = false)
        {
            var root = builder.Build();

            builder.Add(setting =>
            {
                setting.HostEnvironment = hostingEnvironment;
                setting.ApiName = apiName;
                setting.ReqUrl = root.GetSection("GatewayUrl").Value;
                setting.Optional = optional;
            });
        }
    }
}
