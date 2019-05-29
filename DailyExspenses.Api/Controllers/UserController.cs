using System;
using System.ComponentModel.DataAnnotations;
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
            try
            {
                _userService.Create(model.Email, model.Password, model.PasswordConfirm);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                // log Exception
                return StatusCode(500);
            }

            return Ok();
        }
    }
}
