using System;
using DailyExpenses.Api.Models.ExpensesModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DailyExpenses.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(int templateId)
        {
            // TODO: get expenses template by id
            // check user info and rights

            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            // TODO: get all user expenses templates
            // check user info

            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult AddToTemplate(ExpensesToTemplateModel model)
        {
            // TODO: add to user expenses template
            // check user info and rights

            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult AddTemplate(ExpensesTemplateCreationModel model)
        {
            // TODO: add user expenses template
            // check user info and rights

            throw new NotImplementedException();
        }

        [HttpDelete]
        public IActionResult RemoveTemplate(int templateId)
        {
            // check user info and rights

            throw new NotImplementedException();
        }

        [HttpDelete]
        public IActionResult RemoveFromTemplate()
        {
            // check user info and rights

            throw new NotImplementedException();
        }

        [HttpPut]
        public IActionResult UpdateInTemplate()
        {
            // check user info and rights

            throw new NotImplementedException();
        }
    }
}