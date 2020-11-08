using System.Net.Http;

namespace MachineCartSystem.Gateway.WebService
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _basketClient;

        public BasketService(IBasketClient basketClient)
        {
            _basketClient = basketClient.httpClient;
        }


    }
}
