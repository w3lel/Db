using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberAge.Entities
{
    public class User
    {

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid UserGuid { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        [MaxLength(50)]
        public string Login { get; set; }

        /// <summary>
        /// Электронный адрес
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Хэш пароля
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Соль пароля
        /// </summary>
        public string PasswordSalt { get; set; }
    }
}
