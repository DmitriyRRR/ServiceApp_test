using Microsoft.EntityFrameworkCore;
using ServiceApp.Database.Models;

namespace ServiceApp.Database
{
    public class ServiceAppContext : DbContext
    {
        public DbSet<Client> Clients { get; set; } = null;
        public DbSet<Device> Devices { get; set; } = null;
        public DbSet<Part> Parts { get; set; } = null;

        public ServiceAppContext(DbContextOptions<ServiceAppContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Client>().HasData(
                    new Client { Id = 1, Name = "Jhon" },
                    new Client { Id = 2, Name = "Den" },
                    new Client { Id = 3, Name = "Tom" }
                    );
            builder.Entity<Device>().HasData(
                new Device { Id =1, Name="Iphone", Description="Cell phone with 5G" },
                new Device { Id =2, Name="ThinkBook 15", Description="Laptop Lenovo" },
                new Device { Id =3, Name="Samung 870 EVO", Description="SSD" }
                );
            builder.Entity<Part>().HasData();
        }
    }
}
