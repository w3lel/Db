
using CyberAge.Domain.Services.Companies;
using CyberAge.Domain.Services.Users;
using CyberAge.Domain.Services.Users.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace CyberAge.Domain
{
    /// <summary>
    /// Класс-расширение коллекции сервисов
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Добавление Domain
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <returns></returns>
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            //Сервисы
            services.AddScoped<CompanyService>();

            //Пользователи
            services.AddScoped<IUsersService, UsersService>();


            return services;
        }
    }
}
