using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServiceApp.Database.Models;

namespace ServiceApp.Database
{
    public class ServiceAppIdentityContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; } = null;

        public ServiceAppIdentityContext(DbContextOptions<ServiceAppIdentityContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().Property(u=>u.Initials).HasMaxLength(5);

            modelBuilder.HasDefaultSchema("identity");
        }

    }
}
