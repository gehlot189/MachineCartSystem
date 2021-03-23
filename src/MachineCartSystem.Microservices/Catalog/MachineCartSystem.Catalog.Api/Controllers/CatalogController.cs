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
        public CatalogController(ILogger<CatalogController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> Get()
        {
            //throw new System.Exception();
           return Ok(await Task.FromResult<object>(new { age = "catalog" }));
        }
    }
}
