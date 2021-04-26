using MachineCartSystem.Gateway.WebService.Interface;
using System;
using System.Threading.Tasks;

namespace MachineCartSystem.Gateway.WebService
{
    public class TokenConfig : ITokenConfig
    {
        //  private readonly 
        public TokenConfig()
        {

        }

        public Task<string> GetToken()
        {
            throw new NotImplementedException();
        }

        //public async Task<string> GetToken()
        //{
        //    var client = new HttpClient();
        //    var disco = await client.GetDiscoveryDocumentAsync("http://localhost:2000");
        //    if (disco.IsError)
        //    {
        //        Console.WriteLine(disco.Error);
        //        return null;
        //    }

        //    // request token
        //    var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
        //    {
        //        Address = disco.TokenEndpoint,
        //        ClientId = "client",
        //        ClientSecret = "secretKey",
        //        Scope = "api1"
        //    });

        //    if (tokenResponse.IsError)
        //    {
        //        Console.WriteLine(tokenResponse.Error);
        //        return null;
        //    }

        //    Console.WriteLine(tokenResponse.Json);
        //    Console.WriteLine("\n\n");

        //    // call api
        //    var apiClient = new HttpClient();
        //    apiClient.SetBearerToken(tokenResponse.AccessToken);

        //    var response = await apiClient.GetAsync("http://localhost:5000/identity");
        //    if (!response.IsSuccessStatusCode)
        //    {
        //        Console.WriteLine(response.StatusCode);
        //    }
        //    else
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        Console.WriteLine(JArray.Parse(content));
        //    }



        //    return tokenResponse.AccessToken;
        //}
    }
}
