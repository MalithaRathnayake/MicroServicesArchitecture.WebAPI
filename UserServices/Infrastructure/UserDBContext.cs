
using KooBits.MicroServices.UserServices.Configurations;
using KooBits.MicroServices.UserServices.Models;
using Microsoft.EntityFrameworkCore;

namespace KooBits.MicroServices.UserServices.Infrastructure
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) 
            : base(options) 
        { 
        }
        
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        }
    }

}
