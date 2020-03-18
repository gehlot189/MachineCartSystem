using System;
using System.Net.Http;

namespace MachineCartSystem.Gateway.WebService
{
    public abstract class BasketClient : IBasketClient
    {
        private readonly HttpClient _httpClient;

        HttpClient IBasketClient.httpClient => _httpClient;

        public BasketClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://api.github.com/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            _httpClient = httpClient;
        }
    }
}
