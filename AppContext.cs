using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace POSUDA
{
    internal class AppContext : DbContext
    {
        // DbSet для таблицы users
        public DbSet<user> users { get; set; }

        // Настройка подключения к SQLite
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\user\source\repos\POSUDA\users.db");
        }
    }
}
