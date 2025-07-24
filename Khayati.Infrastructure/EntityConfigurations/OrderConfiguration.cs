using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Khayati.Infrastructure.EntityConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.HasMany(c => c.Payments)
                .WithOne(o => o.Order)
                .HasForeignKey(c => c.PaymentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c=>c.Customer)
                .WithMany(o=>o.Orders)
                .HasForeignKey(c=>c.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.OrderGarments)
                .WithOne(o => o.Order)
                .HasForeignKey(c => c.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
