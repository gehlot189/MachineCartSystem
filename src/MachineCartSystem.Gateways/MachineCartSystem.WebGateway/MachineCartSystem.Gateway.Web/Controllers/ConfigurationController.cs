using AutoWrapper.Wrappers;
using MachineCartSystem.Gateway.WebService.Model.OpenIdConfiguration;
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
        public ApiResponse GetIdentityServerConfiguration()
        {
            return new ApiResponse(_openIdConfiguration);
        }
    }
}
