using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Khayati.Infrastructure.EntityConfigurations
{
    public class EmbellishmentTypeConfiguration : IEntityTypeConfiguration<EmbellishmentType>
    {
        public void Configure(EntityTypeBuilder<EmbellishmentType> builder)
        {
            builder.HasMany(c=>c.Embellishmentes)
                .WithOne(o=>o.EmbellishmentType)
                .HasForeignKey(c=>c.EmbellishmentTypeId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
