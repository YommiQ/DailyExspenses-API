using DailyExpenses.Api.Configurations;
using DailyExpenses.Api.Controllers;
using DailyExpenses.Api.Models;
using DailyExpenses.DataLayer;
using DailyExpenses.DataLayer.Repositories;
using DailyExpenses.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Xunit;

namespace Web_api_test
{
    public class UserControllerTest
    {
        // TODO: add user to DB to check for exists and to login.
        // т.к. ломается UserCreation_WhenEmailIsNotExists, если запустить все вместе.

        private readonly UserController _userController;

        readonly UserRegistrationModel _testUser = new UserRegistrationModel
        {
            Email = "test4@test.test",
            Password = "test",
            PasswordConfirm = "test"
        };

        readonly UserLoginModel _userLogin = new UserLoginModel
        {
            Email = "test4@test.test",
            Password = "test"
        };

        public UserControllerTest()
        {
            IOptions<AppSettings> appSettingsOptions = Options.Create(new AppSettings() { Secret = "testSecret123LalaGoodRight" });

            var optionBuilder =
                new DbContextOptionsBuilder<DailyExpensesContext>().UseInMemoryDatabase("DailyExpenses");

            _userController = new UserController(appSettingsOptions, new UserService(new UserRepository(new DailyExpensesContext(optionBuilder.Options))));
        }

        [Fact]
        public void UserCreation_WhenEmailIsNotExists()
        {
            IActionResult actionResult = _userController.Register(_testUser);

            Assert.IsType<OkResult>(actionResult);
        }

        [Fact]
        public void UserCreation_WhenEmailExists()
        {
            _userController.Register(_testUser);
            IActionResult actionResultSame = _userController.Register(_testUser);

            Assert.IsType<BadRequestObjectResult>(actionResultSame);
        }

        [Fact]
        public void UserCreation_WhenPasswordsAreNotEqual()
        {
            _testUser.PasswordConfirm = "test234";

            IActionResult actionResult = _userController.Register(_testUser);


            Assert.IsType<BadRequestObjectResult>(actionResult);
        }

        [Fact]
        public void UserLogin_WhenAllIsRight()
        {
            _userController.Register(_testUser);
            IActionResult actionResult = _userController.Login(_userLogin);

            Assert.IsType<OkObjectResult>(actionResult);
        }
    }
}
