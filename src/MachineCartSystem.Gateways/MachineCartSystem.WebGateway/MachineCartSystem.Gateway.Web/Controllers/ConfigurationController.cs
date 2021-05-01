using AutoWrapper.Wrappers;
using MachineCartSystem.Configuration;
using MachineCartSystem.Gateway.WebService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MachineCartSystem.Gateway.Web.Controllers
{
    [Route("api/[controller]")]
    public class ConfigurationController : BaseController<ConfigurationController>
    {
        private readonly IConfigurationService _configurationService;

        public ConfigurationController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        [HttpGet]
        [Route("getConfig")]
        [AllowAnonymous]
        public async Task<ApiResponse> GetOpenIdConfigurationConfiguration()
        {
            return new ApiResponse(await _configurationService.GetOpenIdConfigurationConfiguration());
        }

        [HttpPost]
        [Route("getApiConfig")]
        [AllowAnonymous]
        public async Task<IActionResult> GetApiConfiguration([FromBody] ApiName apiName)
        {
            return Ok(await _configurationService.GetApiConfiguration(apiName));
        }
    }
}
