using MachineCartSystem.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;

namespace MachineCartSystem.Basket.Service
{
    public class AppSettingProvider : BaseAppSettingProvider
    {
        public override string Resolve(AppSetting appSetting)
        {
            var content = BaseResolve(appSetting);
            return WriteFile(content);
        }

        public override void Add(IConfigurationBuilder builder, IWebHostEnvironment hostingEnvironment)
        {
            base.Add(builder, hostingEnvironment);
        }
    }
}
