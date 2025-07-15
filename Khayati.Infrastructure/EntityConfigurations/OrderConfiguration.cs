using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Khayati.Infrastructure.EntityConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(c=>c.Customer)
                .WithMany(o=>o.Orders)
                .HasForeignKey(c=>c.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
