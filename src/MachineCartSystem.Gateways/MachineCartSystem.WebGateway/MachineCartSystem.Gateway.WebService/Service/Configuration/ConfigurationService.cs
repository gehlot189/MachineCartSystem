﻿using AutoMapper;
using MachineCartSystem.Configuration;
using System.Threading.Tasks;

namespace MachineCartSystem.Gateway.WebService.Service
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly OpenIdConfiguration _openIdConfiguration;
        private readonly GlobalConfiguration _globalConfiguration;
        private readonly IMapper _mapper;

        public ConfigurationService(IMapper mapper, OpenIdConfiguration openIdConfiguration, GlobalConfiguration globalConfiguration)
        {
            _globalConfiguration = globalConfiguration;
            _openIdConfiguration = openIdConfiguration;
            _mapper = mapper;
        }

        public async Task<object> GetApiConfiguration(ApiName apiName)
        {
            object data = null;

            switch (apiName)
            {
                case ApiName.Identity:
                    data = _mapper.Map<IdentityConfig>(_globalConfiguration, p => p.AfterMap((q, r) =>
                    {
                        r.Name = apiName.ToString();
                        r.Description = apiName.GetDescription();
                    }));
                    break;
                case ApiName.Basket:
                    data = _mapper.Map<BasketConfig>(_globalConfiguration, p => p.AfterMap((q, r) =>
                    {
                        r.Name = apiName.ToString(); 
                        r.Description = apiName.GetDescription();
                    }));
                    break;
                case ApiName.Order:
                    data = _mapper.Map<OrderConfig>(_globalConfiguration, p => p.AfterMap((q, r) =>
                    {
                        r.Name = apiName.ToString(); 
                        r.Description = apiName.GetDescription();
                    }));
                    break;
                case ApiName.Catalog:
                    data = _mapper.Map<CatalogConfig>(_globalConfiguration, p => p.AfterMap((q, r) =>
                    {
                        r.Name = apiName.ToString();
                        r.Description = apiName.GetDescription();
                    }));
                    break;
                default:
                    break;
            }
            return await Task.FromResult<object>(data);
        }

        public async Task<OpenIdConfiguration> GetOpenIdConfigurationConfiguration()
        {
            return await Task.FromResult<OpenIdConfiguration>(_openIdConfiguration);
        }
    }
}
