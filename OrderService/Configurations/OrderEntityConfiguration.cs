using KooBits.MicroServices.OrderServices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KooBits.MicroServices.OrderServices.Configurations
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.OrderID);
            builder.Property(e => e.UserId).IsRequired();
            builder.Property(e => e.Product).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Quantity).IsRequired().HasMaxLength(10);
        }
    }
}
