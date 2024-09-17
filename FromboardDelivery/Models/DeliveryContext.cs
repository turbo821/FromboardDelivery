using Microsoft.EntityFrameworkCore;
using FromboardDelivery.Models;
using Microsoft.Extensions.Options;
using FromboardDelivery.Extensions;

namespace FromboardDelivery.Models
{
    public class DeliveryContext : DbContext
    {
        public DbSet<Calculation> Calculations { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Admin> Admins { get; set; } = null!;
        private readonly Admin[] _adminsCred;

        public DeliveryContext(DbContextOptions<DeliveryContext> options, IOptions<AdminCredentials> adminCred)
            : base(options)
        {
            AdminCredentials adminCredentials = adminCred.Value;
            _adminsCred = adminCredentials.Admins;

            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(
                    new Admin { Id = Guid.NewGuid(), Name = _adminsCred[0].Name, Email = _adminsCred[0].Email, Password = _adminsCred[0].Password.Encrypt() },
                    new Admin { Id = Guid.NewGuid(), Name = _adminsCred[1].Name, Email = _adminsCred[1].Email, Password = _adminsCred[1].Password.Encrypt() },
                    new Admin { Id = Guid.NewGuid(), Name = _adminsCred[2].Name, Email = _adminsCred[2].Email, Password = _adminsCred[2].Password.Encrypt() }
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
