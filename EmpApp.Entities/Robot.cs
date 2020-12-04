using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CyberAge.Entities
{
    public class Robot
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid RobotGuid { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        [MaxLength(50)]
        public string Type { get; set; }

        /// <summary>
        /// Здоровье
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Энергия
        /// </summary>
        public int Energy { get; set; }
    }
}
