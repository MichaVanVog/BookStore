using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.NewGuid(),
                Title = "С тобой я дома. Книга о том, как любить друг друга, оставаясь верными себе",
                Author = "Примаченко О.",
                ReleaseYear = 2022
            },

            new Book
            {
                Id = Guid.NewGuid(),
                Title = "Плененный принц",
                Author = "Пакат К.",
                ReleaseYear = 2022
            },

            new Book
            {
                Id = Guid.NewGuid(),
                Title = "Медсестра-заклинательница",
                Author = "Чон С.",
                ReleaseYear = 2021
            },

            new Book
            {
                Id = Guid.NewGuid(),
                Title = "Ведьмак",
                Author = "Сапковский А.",
                ReleaseYear = 2020
            },

            new Book
            {
                Id = Guid.NewGuid(),
                Title = "Гоблин. Останься со мной",
                Author = "Ынсук К., Суен К.",
                ReleaseYear = 2021
            },

            new Book
            {
                Id = Guid.NewGuid(),
                Title = "От первого лица",
                Author = "Мураками Х.",
                ReleaseYear = 2022
            });
        }
    }
}
