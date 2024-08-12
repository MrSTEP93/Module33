using Microsoft.AspNetCore.Mvc;
using System;

namespace Module33.AuthenticationService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private ILogger _logger;

        public UserController(ILogger logger)
        {
            _logger = logger;         
            _logger.WriteEvent("Запуск приложения");
        }

        [HttpGet]
        public User GetUser()
        {
            _logger.WriteEvent("Запрошен пользователь");

            return new User()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                SurName = "Testov",
                Login = "Test",
                Email = "Test@tester.com",
                Password = "1"
            };
        }

        //[HttpGet]
        //public void AddUser()
        //{
        //    _logger.WriteError("Попытка добавить пользователя");
        //}
    }
}
