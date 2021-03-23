using MachineCartSystem.Configuration;
using MachineCartSystem.Gateway.WebService.Service.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineCartSystem.Gateway.Web.Controllers
{
    [ApiController]
    [Route("api/configuration")]
    [Produces("application/json")]
    public class ConfigurationController : GatewayBaseController<ConfigurationController>
    {
        private readonly IOpenIdConfigurationService _openIdConfiguration;
        public ConfigurationController(IOpenIdConfigurationService openIdConfiguration)
        {
            _openIdConfiguration = openIdConfiguration;
        }

        [HttpGet]
        [Route("getConfig")]
        public async Task<IActionResult> GetIdentityServerConfiguration()
        {
            return Ok(await _openIdConfiguration.GetIdentityServerConfiguration());
        }
    }
}
