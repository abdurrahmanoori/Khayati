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
                    Discription = "Various neck styles."
                },
    new EmbellishmentType
    {
        EmbellishmentTypeId = 2,
        Name = "Sleeve",
        Discription = "Different sleeve styles."
    },
    new EmbellishmentType
    {
        EmbellishmentTypeId = 3,
        Name = "Hem",
        Discription = "Different hem styles."
    },
    new EmbellishmentType
    {
        EmbellishmentTypeId = 4,
        Name = "Pocket",
        Discription = "Various pocket styles."
    },
    new EmbellishmentType
    {
        EmbellishmentTypeId = 5,
        Name = "Embroidery",
        Discription = "Different embroidery styles."
    }

        );
        }
    }
}
