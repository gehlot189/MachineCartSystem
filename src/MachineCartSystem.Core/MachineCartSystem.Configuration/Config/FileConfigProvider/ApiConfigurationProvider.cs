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

        public override void Load()
        {
            try
            {
                var data = JsonContent.Create<ApiEnv>(_apiConfigurationSource.ApiEnv);
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PostAsync(_apiConfigurationSource.ReqUrl, data).ConfigureAwait(false).GetAwaiter().GetResult();
                    var res = result.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                    var response = JsonConvert.DeserializeObject<ApiResponse>(res);
                    if (result.StatusCode == HttpStatusCode.OK)
                        Data = JObject.FromObject(response.Result).ToObject<Dictionary<string, string>>();
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