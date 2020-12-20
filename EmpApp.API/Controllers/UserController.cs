using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CyberAge.Authorization.Jwt.Models;
using CyberAge.Domain.Services.Users.Abstractions;
using CyberAge.Domain.Services.Users.Models;
using Microsoft.AspNetCore.Authorization;

namespace CyberAge.API.Controllers
{
    /// <summary>
    /// Контроллер пользователей
    /// </summary>
    //[Authorize("Bearer")]
    [Route("/Users")]
    public class UserController
    {
        private readonly IUsersService _userService;

        public UserController(IUsersService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="registrationModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Registration")]
        public async Task Registration([FromQuery]RegistrationModel registrationModel)
        {
            await _userService.Registration(registrationModel);
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="authorizationModel"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("Authorize")]
        [ProducesResponseType(typeof(Token), 200)]
        public async Task<Token> Authorize(AuthorizationModel authorizationModel)
        {
            var token = await _userService.Authorization(authorizationModel);
            return token;
        }
    }
}
