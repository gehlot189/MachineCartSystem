using AutoWrapper.Wrappers;
using MachineCartSystem.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace MachineCartSystem.Gateway.Web.Controllers
{
    [ApiController]
    [Route("api/configuration")]
    public class ConfigurationController : GatewayBaseController<ConfigurationController>
    {
        private readonly OpenIdConfiguration _openIdConfiguration;

        public ConfigurationController(OpenIdConfiguration openIdConfiguration)
        {
            _openIdConfiguration = openIdConfiguration;
        }

        [HttpGet]
        [Route("getConfig")]
        public ApiResponse GetOpenIdConfigurationConfiguration()
        {
            return new ApiResponse(_openIdConfiguration);
        }

        [HttpGet]
        [Route("getBasketApiConfig")]
        public ApiResponse GetBasketApiConfiguration()
        {
            return new ApiResponse(_openIdConfiguration);
        }
    }
}
