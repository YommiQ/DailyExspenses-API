using System;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DailyExpenses.Api.Configurations;
using DailyExpenses.Api.Models.UserModels;
using DailyExpenses.Domain;
using DailyExpenses.Domain.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

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
            // TODO: add model validation
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

            // TODO: create a service for sending activation emails to users

            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserLoginModel model)
        {
            // TODO: add model validation
            UserViewModel user;

            try
            {
                user = _userService.Authenticate(model.Email, model.Password);
            }
            catch (Exception e)
            {
                // log Exception
                return StatusCode(500);
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return Ok(user);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Activate(string activationLink)
        {
            // TODO: activate user

            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            throw new NotImplementedException();
        }
    }
}
