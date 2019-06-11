using PhonebookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;

namespace PhonebookAPI.Context
{
    /// <summary>
    /// Контекст для работы с БД.
    /// </summary>
    public class PhoneContextApi : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Place> Places { get; set; }

        /// <summary>
        /// Конструктор по умолчанию, создающий таблицы в бд если их нет.
        /// </summary>
        public PhoneContextApi() => Database.EnsureCreated(); 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"server=192.168.5.69;database=phone;user=root;password=kj87dytB;charset=utf8");
        }
    }
}
