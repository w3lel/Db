using System.Threading.Tasks;
using CyberAge.Authorization.Jwt.Models;
using CyberAge.Domain.Services.Users.Models;

namespace CyberAge.Domain.Services.Users.Abstractions
{
    /// <summary>
    /// Интрефейс действий пользователя
    /// </summary>
    public interface IUsersService
    {
        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="registrationModel"></param>
        /// <returns></returns>
        Task Registration(RegistrationModel registrationModel);

        /// <summary>
        /// Авторизация 
        /// </summary>
        /// <param name="authorizationModel"></param>
        /// <returns></returns>
        Task<Token> Authorization(AuthorizationModel authorizationModel);
    }
}
