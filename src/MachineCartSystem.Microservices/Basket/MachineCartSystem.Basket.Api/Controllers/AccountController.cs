﻿using MachineCartSystem.Common;
using MachineCartSystem.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MachineCartSystem.BasketApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy.Admin)]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService _userService;

        public AccountController(IUserService userService, ILogger<AccountController> logger)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var conn = new SqlConnection("Data Source=MYPC;Initial Catalog=MachineCartSystem.v1;Integrated Security=True");

                using (var conn1 = new SqlConnection("Data Source=MYPC;Initial Catalog=MachineCartSystem.v1;Integrated Security=True"))
                {
                    conn.Open();

                    conn1.Open();

                }
            }
            catch (System.Exception ex)
            {

                throw;
            }


            var data = new { age = "basket" };
            System.Threading.Thread.Sleep(9000);
            return await Task.FromResult(Ok(data));
            // var data = await _userService.GetAllUserDetailAsync();
            // var data1 = data.FirstOrDefault();
            //  data1.MiddleName = "m1";
            // await _userService.UpdateUserDetailAsync(data1);
            // return Ok("basket");
        }


    }
}
