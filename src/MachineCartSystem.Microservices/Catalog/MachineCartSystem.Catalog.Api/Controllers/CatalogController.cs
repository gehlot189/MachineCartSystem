using MachineCartSystem.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MachineCartSystem.Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy.Admin)]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> _logger;
        public CatalogController(ILogger<CatalogController>  logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Get()
        {
            return Ok(await Task.FromResult<string>("Catalog api called"));
        }
    }
}
