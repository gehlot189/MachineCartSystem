﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace MachineCartSystem.Configuration
{
    public class AppSettingProvider 
    {
        public static void Add(IConfigurationBuilder builder, IWebHostEnvironment hostingEnvironment, ApiName apiName)
        {
            builder.AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", false, true);
            var root = builder.Build();

            builder.AddAppConfiguration(setting =>
            {
                setting.HostEnvironment = hostingEnvironment;
                setting.ApiName = apiName;
                setting.ReqUrl = root.GetSection("GatewayUrl").Value;
            });
        }
    }
}
