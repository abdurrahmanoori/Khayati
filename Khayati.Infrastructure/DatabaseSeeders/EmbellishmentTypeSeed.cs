using Entities;
using Microsoft.EntityFrameworkCore;

namespace Khayati.Infrastructure.DatabaseSeeders
{
    public static class EmbellishmentTypeSeed
    {
        public static void DataSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmbellishmentType>().HasData(

                new EmbellishmentType
                {
                    EmbellishmentTypeId = 1,
                    Name = "Neck",
                    Description = "Various neck styles."
                },
            new EmbellishmentType
            {
                EmbellishmentTypeId = 2,
                Name = "Sleeve",
                Description = "Different sleeve styles."
            },
            new EmbellishmentType
            {
                EmbellishmentTypeId = 3,
                Name = "Hem",
                Description = "Different hem styles."
            },
            new EmbellishmentType
            {
                EmbellishmentTypeId = 4,
                Name = "Pocket",
                Description = "Various pocket styles."
            },
            new EmbellishmentType
            {
                EmbellishmentTypeId = 5,
                Name = "Embroidery",
                Description = "Different embroidery styles."
            }

     );
        }
    }
}
