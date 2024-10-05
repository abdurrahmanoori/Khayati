using Entities;
using Microsoft.EntityFrameworkCore;

namespace Khayati.Infrastructure.DatabaseSeeders
{
    public static class EmbellishmentSeed
    {
        public static void DataSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Embellishment>().HasData(
               new Embellishment
               {
                   EmbellishmentId = 1,
                   EmbellishmentName = "Circle Neck",
                   EmbellishmentDiscription = "A circular neck style.",
                   Cost = 20,
                   EmbellishmentTypeId = 1 // Neck
               },
    new Embellishment
    {
        EmbellishmentId = 2,
        EmbellishmentName = "V-Neck",
        EmbellishmentDiscription = "A V-shaped neck style.",
        Cost = 25,
        EmbellishmentTypeId = 1 // Neck
    },
    new Embellishment
    {
        EmbellishmentId = 3,
        EmbellishmentName = "Short Sleeve",
        EmbellishmentDiscription = "A short sleeve style.",
        Cost = 15,
        EmbellishmentTypeId = 2 // Sleeve
    },
    new Embellishment
    {
        EmbellishmentId = 4,
        EmbellishmentName = "Long Sleeve",
        EmbellishmentDiscription = "A long sleeve style.",
        Cost = 30,
        EmbellishmentTypeId = 2 // Sleeve
    },
    new Embellishment
    {
        EmbellishmentId = 5,
        EmbellishmentName = "Frayed Hem",
        EmbellishmentDiscription = "A frayed hem style.",
        Cost = 10,
        EmbellishmentTypeId = 3 // Hem
    }
        );
        }
    }
}
