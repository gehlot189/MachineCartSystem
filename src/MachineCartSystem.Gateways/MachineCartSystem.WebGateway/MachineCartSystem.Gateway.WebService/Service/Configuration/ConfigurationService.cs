using MachineCartSystem.Configuration;
using MachineCartSystem.Configuration.Config.FileConfigProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineCartSystem.Gateway.WebService.Service
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly OpenIdConfiguration _openIdConfiguration;

        public ConfigurationService(OpenIdConfiguration openIdConfiguration)
        {
            _openIdConfiguration = openIdConfiguration;
        }

        public async Task<object> GetApiConfiguration(ApiEnv apiEnv)
        {
            return await Task.FromResult<object>(_openIdConfiguration);
        }

        public async Task<object> GetOpenIdConfigurationConfiguration()
        {
            return await Task.FromResult<object>(_openIdConfiguration);
        }
    }
}
