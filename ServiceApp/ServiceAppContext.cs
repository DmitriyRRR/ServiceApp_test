using Microsoft.EntityFrameworkCore;
using ServiceApp.Models;

namespace ServiceApp
{
    public class ServiceAppContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Part> Parts { get; set; }

        public ServiceAppContext(DbContextOptions<ServiceAppContext> options):base(options)
        {
        }
    }
}
