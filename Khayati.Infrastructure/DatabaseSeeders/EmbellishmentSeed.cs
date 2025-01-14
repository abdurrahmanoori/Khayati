using Entities;
using Microsoft.EntityFrameworkCore;

namespace Khayati.Infrastructure.DatabaseSeeders
{
    public static class Embellishmenteed
    {
        public static void DataSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Embellishment>().HasData(
               new Embellishment
               {
                   EmbellishmentId = 1,
                   Name = "Circle Neck",
                   Description = "A circular neck style.",
                   Cost = 20,
                   EmbellishmentTypeId = 1 // Neck
               },
    new Embellishment
    {
        EmbellishmentId = 2,
        Name = "V-Neck",
        Description = "A V-shaped neck style.",
        Cost = 25,
        EmbellishmentTypeId = 1 // Neck
    },
    new Embellishment
    {
        EmbellishmentId = 3,
        Name = "Short Sleeve",
        Description = "A short sleeve style.",
        Cost = 15,
        EmbellishmentTypeId = 2 // Sleeve
    },
    new Embellishment
    {
        EmbellishmentId = 4,
        Name = "Long Sleeve",
        Description = "A long sleeve style.",
        Cost = 30,
        EmbellishmentTypeId = 2 // Sleeve
    },
    new Embellishment
    {
        EmbellishmentId = 5,
        Name = "Frayed Hem",
        Description = "A frayed hem style.",
        Cost = 10,
        EmbellishmentTypeId = 3 // Hem
    }
        );
        }
    }
}
