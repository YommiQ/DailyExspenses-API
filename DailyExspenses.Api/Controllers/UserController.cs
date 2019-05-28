using System.Collections.Generic;
using DailyExpenses.Api.Configurations;
using DailyExpenses.Api.Models;
using DailyExpenses.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DailyExpenses.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IUserService _userService;

        public UserController(IOptions<AppSettings> appSettings, IUserService userService)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] UserRegistrationModel model)
        {
            // TODO: model validation

            _userService.Create(model.Email, model.Password, model.PasswordConfirm);

            return Ok();
        }

        [HttpGet]
        [Route("TestAuth")]
        public IActionResult TestAuth()
        {
            return Ok(new
            {
                IsTest = true,
                Controller = "UserController",
                Anonymous = false
            });
        }

        [HttpGet]
        [Route("TestAnon")]
        [AllowAnonymous]
        public IActionResult TestAnon()
        {
            return Ok(new
            {
                IsTest = true,
                Controller = "UserController",
                Anonymous = true
            });
        }
    }
}
