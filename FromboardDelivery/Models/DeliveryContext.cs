using Microsoft.EntityFrameworkCore;
using FromboardDelivery.Models;

namespace FromboardDelivery.Models
{
    public class DeliveryContext : DbContext
    {
        public DbSet<Calculation> Calculations { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Admin> Admins { get; set; } = null!;

        public DeliveryContext(DbContextOptions<DeliveryContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(
                    new Admin { Id = Guid.NewGuid(), Name = "Tom Smith", Email = "tom32@gmail.com", Password = "admin" },
                    new Admin { Id = Guid.NewGuid(), Name = "Alice Evans", Email = "aliceavans@gmail.com", Password = "super_secret" },
                    new Admin { Id = Guid.NewGuid(), Name = "Sam Roberts", Email = "sam1994@yahoo.com", Password = "password" }
            );

            modelBuilder.Entity<Calculation>().HasData(
                new Calculation { Id = Guid.NewGuid(), Name = "Попов Александр", Email = "popov@gmail.com", PhoneNumber = "+7(965)153-51-63", BuyCountry = "США", BuyCity = "Нью-Йорк", DeliveryRegion = "Ростовская", DeliveryCity = "Волгодонск", Square = 10, Weight = 41 }
            );

                modelBuilder.Entity<Question>().HasData(
                new Question { Id = Guid.NewGuid(), Name = "Колов Евгений", Email = "evgeny@gmail.com", PhoneNumber = "+7(943)322-32-32", Subject = "Стоимость", Message = "Сколько будет стоить доставка из Швеции?" }
            );
        }
    }
}
