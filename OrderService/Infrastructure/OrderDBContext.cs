using KooBits.MicroServices.OrderServices.Configurations;
using KooBits.MicroServices.OrderServices.Models;
using Microsoft.EntityFrameworkCore;

namespace KooBits.MicroServices.OrderServices.Infrastructure
{
    public class OrderDBContext : DbContext
    {
        public OrderDBContext(DbContextOptions<OrderDBContext> options) : base(options) { }
        public DbSet<Order> Orders { get; set; }
        //TODO : Need to ADD RefUsers table and config User Microservice to Order Microservice Consumer/Subuscriber patter via KAFKA

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
        }
    }
}
