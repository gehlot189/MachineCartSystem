using MachineCartSystem.Common;
using MachineCartSystem.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.IdentityModel;

namespace MachineCartSystem.BasketApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy.Admin)]
    public class AccountController : BasketBaseController<AccountController>
    {
        public AccountController()
        {

        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> Get()
        {
            var data = new { age = "basket" };
            // System.Threading.Thread.Sleep(9000);
            return await Task.FromResult(Ok(data));
            // var data = await _userService.GetAllUserDetailAsync();
            // var data1 = data.FirstOrDefault();
            //  data1.MiddleName = "m1";
            // await _userService.UpdateUserDetailAsync(data1);
            // return Ok("basket");
        }
    }
}
