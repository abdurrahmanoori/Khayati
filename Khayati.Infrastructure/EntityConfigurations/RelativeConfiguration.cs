using Khayati.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Khayati.Infrastructure.EntityConfigurations
{
    public class RelativeConfiguration : IEntityTypeConfiguration<Relative>
    {
        public void Configure(EntityTypeBuilder<Relative> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);
            //builder.Property(f => f.FabricId).IsRequired(false);
            //builder.HasOne(c=>c.Customer)
            //    .WithMany(o=>o.Relatives)
            //    .HasForeignKey(c=>c.CustomerId)
            //    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
