﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace MachineCartSystem.Configuration.Config.FileConfigProvider
{
    public sealed class ApiConfigurationSource : ApiEnv, IConfigurationSource
    {
        private int? _period = 60;

        public string ReqUrl { get; set; }
        public int? Period { get => _period; set => _period = value ?? _period; }
        public bool Optional { get; set; }
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new ApiConfigurationHandler(this);
        }
    }

    public class ApiEnv
    {
        public ApiName ApiName  { get; set; }
        public IWebHostEnvironment HostEnvironment { get; set; }
    }
}
