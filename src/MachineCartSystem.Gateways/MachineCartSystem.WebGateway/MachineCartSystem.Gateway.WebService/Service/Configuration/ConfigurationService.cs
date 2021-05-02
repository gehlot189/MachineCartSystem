using AutoMapper;
using MachineCartSystem.Configuration;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineCartSystem.Gateway.WebService.Service
{
    public class ConfigurationService : BaseConfiguration, IConfigurationService
    {
        private readonly GlobalConfiguration _globalConfiguration;
        private readonly IMapper _mapper;
        private ClientConfiguration _clientConfiguration;

        public ConfigurationService(IMapper mapper, IConfiguration configuration, ClientConfiguration clientConfiguration,
            GlobalConfiguration globalConfiguration) : base(configuration)
        {
            _mapper = mapper;
            _globalConfiguration = _mapper.Map<GlobalConfiguration>(globalConfiguration);
            _clientConfiguration = clientConfiguration;
        }

        public async Task RefreshGatewayConfiguration()
        {
            await GetApiConfiguration(ApiName.Gateway);
        }

        public async Task<object> GetApiConfiguration(ApiName apiName)
        {
            object data = null;

            switch (apiName)
            {
                case ApiName.Gateway:
                    {
                        var gatewayConfig = _mapper.Map<GatewayConfig>(_globalConfiguration);
                        foreach (var item in gatewayConfig.GetType().GetProperties().Where(p => !new string[] { "Scopes", "Audiences" }.Any(q => q == p.Name)))
                        {
                            Configuration[item.Name] = item.GetValue(gatewayConfig)?.ToString();
                        }
                    }
                    break;
                case
                ApiName.Identity:
                    data = _mapper.Map<IdentityConfig>(_globalConfiguration);
                    break;
                case ApiName.Basket:
                    data = _mapper.Map<BasketConfig>(_globalConfiguration);
                    break;
                case ApiName.Order:
                    data = _mapper.Map<OrderConfig>(_globalConfiguration);
                    break;
                case ApiName.Catalog:
                    data = _mapper.Map<CatalogConfig>(_globalConfiguration);
                    break;
                default:
                    break;
            }
            return await Task.FromResult<object>(data);
        }

        public async Task<ClientConfiguration> GetOpenIdConfigurationConfiguration()
        {
            _clientConfiguration = _mapper.Map(_globalConfiguration, _clientConfiguration);
            var scopes = new List<string> { "openid" };
            scopes.AddRange(GetAllScopesAndAudiences().Item1);
            _clientConfiguration.OpenIdConfiguration.Scope = string.Join(" ", scopes);
            return await Task.FromResult<ClientConfiguration>(_clientConfiguration);
        }
    }
}   
