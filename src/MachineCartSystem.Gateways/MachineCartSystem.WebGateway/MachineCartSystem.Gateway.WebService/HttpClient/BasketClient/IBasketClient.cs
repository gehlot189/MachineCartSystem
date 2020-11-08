using System.Net.Http;

namespace MachineCartSystem.Gateway.WebService
{
    public interface IBasketClient
    {
        HttpClient httpClient { get; }
    }
}
