using MachineCartSystem.Common;
using MachineCartSystem.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MachineCartSystem.Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize()]

    public class CatalogController : BaseController<CatalogController>
    {
        public CatalogController()
        {
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
