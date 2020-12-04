using CyberAge.Entities;
using Microsoft.EntityFrameworkCore;

namespace CyberAge.Database
{
    public class DatabaseContext : DbContext
    {
        /// <inheritdoc />
        public DatabaseContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Пользователи
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// Роли пользователей
        /// </summary>
        public virtual DbSet<Robot> UserRoles { get; set; }
    }
}
