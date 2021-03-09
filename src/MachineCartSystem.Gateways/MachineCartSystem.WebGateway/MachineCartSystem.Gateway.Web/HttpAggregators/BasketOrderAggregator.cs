using Microsoft.AspNetCore.Http;
using MMLib.SwaggerForOcelot.Aggregates;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MachineCartSystem.Gateway.Web.HttpAggregators
{
    [AggregateResponse("Basket with buyer and basket items.", typeof(BasketOrderAggregator))]

    public class BasketOrderAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            var dcResponse = new Dictionary<string, JObject>();

            foreach (var context in responses)
            {
                var data = await context.Items.DownstreamResponse().Content.ReadAsStringAsync();
                dcResponse.Add(context.Items.DownstreamRoute().Key,
                    JsonConvert.DeserializeObject<JObject>(data));
            }

            var stringContent = new StringContent(JsonConvert.SerializeObject(dcResponse))
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };
            var headers = responses.SelectMany(x => x.Items.DownstreamResponse().Headers).ToList();

            var response = new DownstreamResponse(stringContent, HttpStatusCode.OK, headers, "OK");
            return response;
        }
    }
}
