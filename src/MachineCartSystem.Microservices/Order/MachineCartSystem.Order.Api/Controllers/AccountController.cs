﻿using MachineCartSystem.Common;
using MachineCartSystem.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MachineCartSystem.Order.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Permissions(Permissions = new[] { Permission.full }, Roles = new[] { Role.buisness_head }, Scopes = new[] { "order.read" })]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult Get()
        {
            var data = new { age = "order" };
            return Ok(data);
        }
    }
}
