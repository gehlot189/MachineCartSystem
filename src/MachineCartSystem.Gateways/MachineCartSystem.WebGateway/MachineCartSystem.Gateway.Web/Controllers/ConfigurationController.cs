using AutoWrapper.Wrappers;
using MachineCartSystem.Configuration;
using MachineCartSystem.Gateway.WebService.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MachineCartSystem.Gateway.Web.Controllers
{
    [ApiController]
    [Route("api/configuration")]
    public class ConfigurationController : GatewayBaseController<ConfigurationController>
    {
        private readonly IConfigurationService _configurationService;

        public ConfigurationController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        [HttpGet]
        [Route("getConfig")]
        public async Task<ApiResponse> GetOpenIdConfigurationConfiguration()
        {
            return new ApiResponse(await _configurationService.GetOpenIdConfigurationConfiguration());
        }

        [HttpPost]
        [Route("getApiConfig")]
        public async Task<IActionResult> GetApiConfiguration(Api api)
        {
            return  Ok(await _configurationService.GetApiConfiguration(api));
        }
    }
}
