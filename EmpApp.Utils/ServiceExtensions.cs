using CyberAge.Utils.HashProvider.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace CyberAge.Utils
{
    /// <summary>
    /// Класс-расширение коллекции утилит
    /// </summary>
    public static class UtilsExtensions
    {
        /// <summary>
        /// Добавление Utils
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <returns></returns>
        public static IServiceCollection AddUtils(this IServiceCollection services)
        {

            services.AddScoped<IHashProvider, HashProvider.HashProvider>();
            return services;
        }
    }
}
