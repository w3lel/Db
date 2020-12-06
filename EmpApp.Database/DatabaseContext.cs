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
        /// Роли сотрудников
        /// </summary>
        public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }
        
        /// <summary>
        /// Сотрудники
        /// </summary>
        public virtual DbSet<Employee> Employees { get; set; }
        
        /// <summary>
        /// Компании
        /// </summary>
        public virtual DbSet<Company> Companies { get; set; }
        
        /// <summary>
        /// Филиалы
        /// </summary>
        public virtual DbSet<SisterСompany> SisterCompanies { get; set; }
        
        /// <summary>
        /// Комманды
        /// </summary>
        public virtual DbSet<Team> Teams { get; set; }
        
        /// <summary>
        /// Задачи
        /// </summary>
        public virtual DbSet<Ticket> Tickets { get; set; }
    }
}
