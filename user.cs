using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSUDA
{
    // Сопоставляем класс с таблицей users
    [Table("users")]
    internal class user
    {
        // PK
        [Column("id")]
        public int id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("role")]
        public string Role { get; set; }

        // Пустой конструктор обязателен для EF Core
        public user() { }

        // Конструктор для удобного создания объектов
        public user(string name, string login, string password, string role)
        {
            Name = name;
            Login = login;
            Password = password;
            Role = role;
        }

        // Для удобной отладки
        public override string ToString()
        {
            return $"id={id}, Name='{Name}', Login='{Login}', Password='{Password}', Role='{Role}'";
        }
    }
}
