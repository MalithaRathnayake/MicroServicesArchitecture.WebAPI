using KooBits.Domain.Models;
using KooBits.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace KooBits.Infrastructure.Data
{
    public class OrderDBContext : DbContext
    {
        public OrderDBContext(DbContextOptions<OrderDBContext> options) : base(options) { }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
        }
    }
}
