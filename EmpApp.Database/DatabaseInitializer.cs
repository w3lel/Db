﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CyberAge.Entities;
using CyberAge.Utils.HashProvider.Abstractions;
using CyberAge.Utils.RandomExtensions;
using Microsoft.EntityFrameworkCore;

namespace CyberAge.Database
{
    /// <summary>
    /// Инициализатор БД
    /// </summary>
    public class DatabaseInitializer
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IHashProvider _hashProvider;

        /// <summary/>
        public DatabaseInitializer(DatabaseContext databaseContext, IHashProvider hashProvider)
        {
            _databaseContext = databaseContext;
            _hashProvider = hashProvider;
        }

        /// <summary>
        /// Инициализация данных БД
        /// </summary>
        /// <returns></returns>
        public async Task Initialize()
        {

            if (!await _databaseContext.Users.AnyAsync())
            {

                #region Пользователи

                var adminSalt = new Random().GenerateSequence(16);
                var admin = new User()
                {
                    Login = "Lemov",
                    Name = "SD",
                    Email = "sfa28134@eoopy.com",
                    PasswordHash = _hashProvider.HashString("3228",adminSalt), // fX7nZzbZlODInUuDmW3RYg==
                    PasswordSalt = adminSalt
                };

                _databaseContext.Users.Add(admin);

                #endregion

                
            }

            await _databaseContext.SaveChangesAsync();
        }
    }
}
