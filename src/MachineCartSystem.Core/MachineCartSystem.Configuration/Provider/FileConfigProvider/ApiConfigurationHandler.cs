using AutoWrapper.Wrappers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Json;

namespace MachineCartSystem.Configuration.Config.FileConfigProvider
{
    public class ApiConfigurationHandler : ConfigurationProvider, IDisposable
    {
        private readonly ApiConfigurationSource _apiConfigurationSource;
        //private readonly Timer _timer;

        public ApiConfigurationHandler(ApiConfigurationSource apiConfigurationSource)
        {
            _apiConfigurationSource = apiConfigurationSource;
            _apiConfigurationSource.ReqUrl += "api/configuration/getApiConfig";
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
                if (!_apiConfigurationSource.Optional)
                {
                    var data = JsonContent.Create<ApiName>(_apiConfigurationSource.ApiName);
                    using (HttpClient client = new HttpClient())
                    {
                        if (IsSericeReady(client, data, out HttpResponseMessage httpResponse))
                        {
                            var res = httpResponse.Content.ReadAsStringAsync().Result;
                            var response = JsonConvert.DeserializeObject<ApiResponse>(res);
                            if (!response.IsError.Value)
                            {
                             //   Data = JObject.Parse(JsonConvert.SerializeObject(response.Result)).ToObject<Dictionary<string, string>>();
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void Dispose()
        {
            // _timer?.Change(Timeout.Infinite, 0);
            //_timer?.Dispose();
        }

        private bool IsSericeReady(HttpClient client, JsonContent data, out HttpResponseMessage httpResponse)
        {
            bool _isSericeReady = false;
            httpResponse = null;
            var expireTime = DateTime.Now.AddSeconds(30);
            do
            {
                try
                {
                    httpResponse = client.PostAsync(_apiConfigurationSource.ReqUrl, data).Result;
                    _isSericeReady = httpResponse.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                }
            }
            while (expireTime > DateTime.Now && !_isSericeReady);
            if (!_isSericeReady)
                throw new Exception("Gateway service is not available");
            return _isSericeReady;
        }
    }
}