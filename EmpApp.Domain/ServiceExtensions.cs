
using CyberAge.Domain.Services.Companies;
using CyberAge.Domain.Services.Employees;
using CyberAge.Domain.Services.proekt;
using CyberAge.Domain.Services.SisterCompany;
using CyberAge.Domain.Services.Tasks;
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
            services.AddScoped<UsersService>();
            services.AddScoped<EmployeeService>();
            services.AddScoped<TeamService>();
            services.AddScoped<SisterService>();
            services.AddScoped<ProektService>();
            services.AddScoped<TicketService>();
            services.AddScoped<CompanyService>();

            //Пользователи
            services.AddScoped<IUsersService, UsersService>();


            return services;
        }
    }
}
