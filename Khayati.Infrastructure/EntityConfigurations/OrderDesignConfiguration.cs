using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Khayati.Infrastructure.EntityConfigurations
{
    public class OrderDesignConfiguration : IEntityTypeConfiguration<OrderDesign>
    {
        public void Configure(EntityTypeBuilder<OrderDesign> builder)
        {
            builder.Property(f => f.FabricId).IsRequired(false);
            //builder.HasOne(c=>c.Customer)
            //    .WithMany(o=>o.OrderDesigns)
            //    .HasForeignKey(c=>c.CustomerId)
            //    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
