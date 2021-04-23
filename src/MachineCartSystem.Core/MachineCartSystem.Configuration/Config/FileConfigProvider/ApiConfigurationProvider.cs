using AutoWrapper.Server;
using AutoWrapper.Wrappers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace MachineCartSystem.Configuration.Config.FileConfigProvider
{
    public class ApiConfigurationProvider : ConfigurationProvider, IDisposable
    {
        private readonly ApiConfigurationSource _apiConfigurationSource;
        //private readonly Timer _timer;

        public ApiConfigurationProvider(ApiConfigurationSource apiConfigurationSource)
        {
            _apiConfigurationSource = apiConfigurationSource;
            _apiConfigurationSource.ReqUrl += "/api/configuration/getApiConfig";
            Load();

            /*  _timer = new Timer(x => Load(),
              null,
              TimeSpan.FromSeconds(_apiConfigurationSource.Period.Value),
              TimeSpan.FromSeconds(_apiConfigurationSource.Period.Value));
            */
        }

        public async override void Load()
        {
            try
            {
                var data = JsonContent.Create<ApiEnv>(new ApiEnv { Environment = _apiConfigurationSource.HostEnvironment.EnvironmentName, ApiName = _apiConfigurationSource.ApiName });
                using (HttpClient client = new HttpClient())
                {
                    var httpResponse = await client.PostAsync(_apiConfigurationSource.ReqUrl, data);
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var res = await httpResponse.Content.ReadAsStringAsync();
                       // Data = Unwrapper.Unwrap<Dictionary<string, string>>(res);
                        JsonResolver.ResolveGatewayAppSettingConfiguration(_apiConfigurationSource.HostEnvironment, "appsetting");
                    }
                    else
                        CheckOptional();
                }
            }
            catch
            {
                CheckOptional();
            }
        }

        private void CheckOptional()
        {
            if (!_apiConfigurationSource.Optional)
            {
                throw new Exception($"can not load config from {_apiConfigurationSource.ReqUrl}");
            }
        }

        public void Dispose()
        {
            // _timer?.Change(Timeout.Infinite, 0);
            //_timer?.Dispose();
        }

    }
}