using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineCartSystem.Configuration
{
    public class BaseAppSettingProvider : BaseAppSettingResolver
    {
        public override string Resolve(AppSetting appSetting)
        {
            var content = BaseResolve(appSetting);
            return WriteFile(content);
        }

        public virtual void Add(IConfigurationBuilder p, IWebHostEnvironment hostingEnvironment)
        {
            p.AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", false, true);
            var root = p.Build();

            p.AddAppConfiguration(setting =>
            {
                setting.Environment = hostingEnvironment.EnvironmentName;
                setting.ApiName = ApiConstant.Basket;
                setting.ReqUrl = root.GetSection("GatewayUrl").Value;
            });
        }
    }
}
