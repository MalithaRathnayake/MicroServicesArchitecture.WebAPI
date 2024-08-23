using KooBits.Domain.Models;
using KooBits.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace KooBits.Infrastructure.Data
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
