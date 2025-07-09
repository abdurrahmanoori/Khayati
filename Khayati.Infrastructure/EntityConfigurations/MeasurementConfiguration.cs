using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Khayati.Infrastructure.EntityConfigurations
{
    public class MeasurementConfiguration : IEntityTypeConfiguration<Measurement>
    {
        public void Configure(EntityTypeBuilder<Measurement> builder)
        {
           
            //builder.HasOne(c=>c.Customer)
            //    .WithMany(o=>o.Measurements)
            //    .HasForeignKey(c=>c.CustomerId)
            //    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
