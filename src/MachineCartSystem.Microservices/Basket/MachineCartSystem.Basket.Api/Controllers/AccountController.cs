using MachineCartSystem.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MachineCartSystem.BasketApi.Controllers
{
    [Route("api/[controller]")]
    [Permissions(Permissions = new[] { Permission.full }, Roles = new[] { Role.buisness_head }, Scopes = new[] { "basket.read" })]

    public class AccountController : BaseController<AccountController>
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
