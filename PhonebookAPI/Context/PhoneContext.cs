using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using PhonebookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonebookAPI.Context
{
    public class PhoneContext : DbContext
    {
        public PhoneContext(DbContextOptions<PhoneContext> options)
              : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<Place> Places { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"Server=192.168.5.69;Database=phone;user=root;password=kj87dytB;");
        }
    }
}