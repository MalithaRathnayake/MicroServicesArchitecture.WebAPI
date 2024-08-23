using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KooBits.Infrastructure.Repositories;
using KooBits.Domain.Models;

namespace KooBits.Infrastructure.Configurations
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
