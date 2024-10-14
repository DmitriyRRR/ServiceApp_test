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
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Client>().HasData(
                    new Client { Id = 1, Name = "Jhon" },
                    new Client { Id = 2, Name = "Den" },
                    new Client { Id = 3, Name = "Tom" },
                    new Client { Id = 4, Name = "William" },
                    new Client { Id = 5, Name = "Bob" },
                    new Client { Id = 6, Name = "Sub-zero" },
                    new Client { Id = 7, Name = "Scorpio" },
                    new Client { Id = 8, Name = "G.Freeman" },
                    new Client { Id = 9, Name = "G.Man" },
                    new Client { Id = 10, Name = "Stevie" }
                    );
            builder.Entity<Device>().HasData(
                new Device { Id = 1, Name = "Iphone", Description = "Cell phone with 5G", ClientId = 1 },
                new Device { Id = 2, Name = "ThinkBook 15", Description = "Laptop Lenovo", ClientId = 1 },
                new Device { Id = 3, Name = "Samung 870 EVO", Description = "SSD", ClientId = 3 },
                new Device { Id = 4, Name = "HP ENVY 15", Description = "Laptop HP", ClientId = 2 },
                new Device { Id = 5, Name = "Edifier 830", Description = "Earphones, wireless", ClientId = 3 }
                );
            builder.Entity<Part>().HasData(
                new Part { Id=1, Name="main flex", Description="n.a.", DeviceId=2},
                new Part { Id=2, Name="battery Iph.6S", Description="for Iphone 6s", DeviceId =1},
                new Part { Id=3, Name="Main camera Iph.XS", Description="n.a."},
                new Part { Id=4, Name="Top case", Description="n.a."},
                new Part { Id=5, Name="Keyboard", Description="n.a."},
                new Part { Id=6, Name="Speaker", Description="n.a."},
                new Part { Id=7, Name="LCD flex", Description="n.a."}
                );
        }
    }
}
