using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using CyberAge.Authorization.Jwt.Abstractions;
using CyberAge.Authorization.Jwt.Models;
using CyberAge.Database;
using CyberAge.Domain.Services.Users.Abstractions;
using CyberAge.Domain.Services.Users.Models;
using CyberAge.Entities;
using CyberAge.Utils.HashProvider.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CyberAge.Domain.Services.Users
{
    /// <summary>
    /// Класс реализующий интерфейс действий пользователя
    /// </summary>
    public class UsersService : IUsersService
    {
        private readonly DatabaseContext _context;
        private readonly ITokenAuthorization _tokenAuthorizationService;
        private readonly IHashProvider _hashProvider;

        public UsersService(DatabaseContext context, ITokenAuthorization tokenAuthorizationService, IHashProvider hashProvider)
        {
            _context = context;
            _tokenAuthorizationService = tokenAuthorizationService;
            _hashProvider = hashProvider;
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="authorizationModel"></param>
        /// <returns></returns>
        public async Task<Token> Authorization(AuthorizationModel authorizationModel)
        {
            var existingUser = await _context.Users.SingleOrDefaultAsync(x => x.Login == authorizationModel.Login);
            if (existingUser != null)
            {
                if (_hashProvider.HashString(authorizationModel.Password,existingUser.PasswordSalt) == existingUser.PasswordHash)
                {
                    var identity = new ClaimsIdentity(new GenericIdentity(authorizationModel.Login), new[] { new Claim("login", authorizationModel.Login), new Claim("email", existingUser.Email ?? string.Empty) });
                    var token = await _tokenAuthorizationService.GetToken(identity);
                    return token;
                }
                else
                {
                    throw new Exception("Неверный пароль");
                }
            }
            else
            {
                throw new Exception("Пользователь с таким логином не найден");
            }
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="registrationModel"></param>
        /// <returns></returns>
        public async Task Registration(RegistrationModel registrationModel)
        {
            var salt = Convert.ToString(Guid.NewGuid());
            User user = new User
            {
                Login = registrationModel.Login,
                Email = registrationModel.Mail,
                Name = registrationModel.Name,
                PasswordSalt = salt,
                PasswordHash = _hashProvider.HashString(registrationModel.Password)
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
