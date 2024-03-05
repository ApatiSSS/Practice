using Microsoft.EntityFrameworkCore;
using Practice.news;
using Practice.users;

namespace Practice
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                Id = 1,
                Family = "Иванов",
                Name = "Иван",
                Patronymic = "Иванович",
                Email = "ivanov@example.com",
                Password = "password",
            });
        }
        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<NewsEntity> News => Set<NewsEntity>();
    }
}