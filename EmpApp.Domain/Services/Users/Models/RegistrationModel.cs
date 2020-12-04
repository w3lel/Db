using System;
using System.Collections.Generic;
using System.Text;

namespace CyberAge.Domain.Services.Users.Models
{
    /// <summary>
    /// Модель регистрации
    /// </summary>
    public class RegistrationModel
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Почта
        /// </summary>
        public string Mail { get; set; }


        /// <summary>
        /// Имя 
        /// </summary>
        public string Name { get; set; }

    }
}
