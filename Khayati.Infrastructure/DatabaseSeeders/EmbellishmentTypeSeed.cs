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
                    EmbellishmentTypeName = "Neck",
                    EmbellishmentTypeDiscription = "Various neck styles."
                },
    new EmbellishmentType
    {
        EmbellishmentTypeId = 2,
        EmbellishmentTypeName = "Sleeve",
        EmbellishmentTypeDiscription = "Different sleeve styles."
    },
    new EmbellishmentType
    {
        EmbellishmentTypeId = 3,
        EmbellishmentTypeName = "Hem",
        EmbellishmentTypeDiscription = "Different hem styles."
    },
    new EmbellishmentType
    {
        EmbellishmentTypeId = 4,
        EmbellishmentTypeName = "Pocket",
        EmbellishmentTypeDiscription = "Various pocket styles."
    },
    new EmbellishmentType
    {
        EmbellishmentTypeId = 5,
        EmbellishmentTypeName = "Embroidery",
        EmbellishmentTypeDiscription = "Different embroidery styles."
    }

        );
        }
    }
}
