using MachineCartSystem.Gateway.WebService.Model.OpenIdConfigurationService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace MachineCartSystem.Gateway.WebService.Service.Configuration
{
    public class OpenIdConfigurationService : IOpenIdConfigurationService
    {
        private readonly OpenIdConfiguration _openIdConfiguration;

        public OpenIdConfigurationService(IConfiguration configuration, IOptionsMonitor<OpenIdConfiguration> options)
        {
            var ff = configuration.GetSection("openIdConfiguration").Value;

            _openIdConfiguration = configuration.GetSection("openIdConfiguration").Get<OpenIdConfiguration>(p => p.BindNonPublicProperties = true);
            configuration.GetSection("openIdConfiguration").Bind(_openIdConfiguration);
            _openIdConfiguration = options.CurrentValue;
        }

        public async Task<OpenIdConfiguration> GetIdentityServerConfiguration()
        {
            return await Task.FromResult<OpenIdConfiguration>(_openIdConfiguration);
        }

        //private readonly OpenIdConfiguration _openIdConfiguration;

        //public OpenIdConfigurationService(IOptions<OpenIdConfiguration> options)
        //{
        //    _openIdConfiguration = options.Value;
        //}
    }
}
