using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Module33.AuthenticationService.Exceptions;
using Module33.AuthenticationService.Models;
using Module33.AuthenticationService.Models.Repositopries;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Module33.AuthenticationService.Controllers
{
    [ExceptionHandler]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private ILogger _logger;
        private IMapper _mapper;
        private IUserRepository _userRepository;

        public UserController(ILogger logger, IMapper mapper, IUserRepository userRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _userRepository = userRepository;
            _logger.WriteEvent("Запуск приложения");    
        }

        [HttpGet]
        public User GetUser()
        {
            _logger.WriteEvent("Запрошен пользователь");

            return _userRepository.GetByLogin("Test");
        }

        [HttpGet]
        [Route("addUser")]
        public void AddUser()
        {
            _logger.WriteError("Попытка добавить пользователя");
        }

        [Authorize(Roles = "Администратор")]
        [HttpGet]
        [Route("viewmodel")]
        public UserViewModel GetUserViewModel()
        {
            _logger.WriteEvent("Запрошена ViewModel пользователя");

            var userViewModel = _mapper.Map<UserViewModel>(_userRepository.GetByLogin("Test"));

            return userViewModel;
        }

        [HttpGet]
        [Route("authenticate")]
        public async Task<UserViewModel> Authenticate(string login, string password)
        {
            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(password))
                throw new ArgumentNullException("Запрос не корректен");

            User user = _userRepository.GetByLogin(login) ?? throw new AuthenticationException("Пользователь на найден");

            if (user.Password != password)
                throw new AuthenticationException("Введенный пароль не корректен");

            var claims = new List<Claim>()
            {
                new(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
            };

            ClaimsIdentity claimsIdentity = new(claims,
                "AppCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return _mapper.Map<UserViewModel>(user);
        }
    }
}
