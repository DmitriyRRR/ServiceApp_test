using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServiceApp.Database.Models;

namespace ServiceApp.Database
{
    public class ServiceAppContext : IdentityDbContext<User>
    {
        public DbSet<Client> Clients { get; set; } = null;
        public DbSet<Device> Devices { get; set; } = null;
        public DbSet<Part> Parts { get; set; } = null;
        public DbSet<User> Users { get; set; } = null;

        public ServiceAppContext(DbContextOptions<ServiceAppContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().Property(u=>u.Initials).HasMaxLength(5);

            modelBuilder.HasDefaultSchema("identity");
            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, Name = "Jhon" },
                new Client { Id = 2, Name = "Den" },
                new Client { Id = 3, Name = "Tom" }
                );
        }

    }
}
