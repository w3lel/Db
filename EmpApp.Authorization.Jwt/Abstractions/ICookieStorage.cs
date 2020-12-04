using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CyberAge.Authorization.Jwt.Abstractions
{
    /// <summary>
    /// Интерфейс для хранения Cookie
    /// </summary>
    public interface ICookieStorage
    {
        /// <summary>
        /// Сохранение Cookie по идентификатору
        /// </summary>
        /// <param name="cookieGuid"> Идентификатор Cookie </param>
        /// <param name="cookie"> Контейнер с Cookie </param>
        /// <returns><see cref="Task"/></returns>
        Task SaveCookie(Guid cookieGuid, CookieContainer cookie);

        /// <summary>
        /// Получение Cookie по идентификатору
        /// </summary>
        /// <param name="cookieGuid"> Идентификатор Cookie </param>
        /// <returns> Контейнер с Cookie </returns>
        Task<CookieContainer> GetCookie(Guid cookieGuid);
    }
}
