using SportsStore.Domain.Entities;
using System.Data.Entity;

namespace SportsStore.Domain.Concrete
{
    // класса контекста, который будет связывать нашу простую модель
    // с базой данных
    // Этот класс будет автоматически определять свойство для каждой
    // таблицы в базе данных, с которой мы будем работать
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
