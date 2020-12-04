using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using CyberAge.Authorization.Jwt.Abstractions;
using CyberAge.Authorization.Jwt.Models;
using CyberAge.Authorization.Jwt.Providers;
using CyberAge.Authorization.Jwt.Service;

namespace CyberAge.Authorization.Jwt
{
   

        public static class ServiceExtensions
        {
            ///<summary>
            /// Добавление сервисов авторизации
            /// </summary>
            public static IServiceCollection AddIdentityServices(this IServiceCollection services, Action<IdentityOptions> configure)
            {
                var options = new IdentityOptions();
                configure(options);
                services.AddSingleton(options);

                //Services
                services.AddScoped<ITokenAuthorization, JwtTokenAuthService>();
                services.AddScoped<ICookieStorage, CookieStorageService>();

                //SessionContext
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

                return services;
            }
        }
    
}
