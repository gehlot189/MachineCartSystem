﻿using Microsoft.AspNetCore.Http;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MachineCartSystem.Gateway.WebService.Aggregators
{
    public class BasketOrderAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            var contentBuilder = new StringBuilder();
            foreach (var context in responses)
            {
                contentBuilder.Append(await context.Items.DownstreamResponse().Content.ReadAsStringAsync());
                contentBuilder.Append(",");
            }

            var stringContent = new StringContent(contentBuilder.ToString())
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };

            return new DownstreamResponse(stringContent, HttpStatusCode.OK,
            responses.SelectMany(x => x.Items.DownstreamResponse().Headers).ToList(), "OK");
        }
    }
}
