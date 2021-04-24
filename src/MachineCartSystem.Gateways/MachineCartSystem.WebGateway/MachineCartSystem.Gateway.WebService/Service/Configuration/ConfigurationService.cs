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

        public async Task<object> GetApiConfiguration(Api api)
        {
            object data = null;

            switch (api)
            {
                case Api.Basket:
                    data = _mapper.Map<BasketConfig>(_globalConfiguration);
                    break;
                case Api.Order:
                    data = _mapper.Map<OrderConfig>(_globalConfiguration);
                    break;
                case Api.Catalog:
                    data = _mapper.Map<CatalogConfig>(_globalConfiguration);
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
