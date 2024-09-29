using Microsoft.EntityFrameworkCore;
using ServiceApp.Models;

namespace ServiceApp
{
    public class ServiceAppContext : DbContext
    {
        public DbSet<Client> Clients { get; set; } = null;
        public DbSet<User> Users { get; set; } = null;
        public DbSet<Device> Devices { get; set; } = null;
        public DbSet<Part> Parts { get; set; } = null;

        public ServiceAppContext(DbContextOptions<ServiceAppContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, Name = "Jhon" },
                new Client { Id = 2, Name = "Den" },
                new Client { Id = 3, Name = "Tom" }
                );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Sam", Email="sam@mail.com", Password="qwerty"},
                new User { Id = 2, Name = "Scott", Email="scott@gmail.com", Password = "qwerty" },
                new User { Id = 3, Name = "Bill", Email="bill@yahoo.com", Password = "qwerty" }
                );
        }
    }
}
