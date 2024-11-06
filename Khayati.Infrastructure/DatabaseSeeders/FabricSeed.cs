using Khayati.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Khayati.Infrastructure.DatabaseSeeders
{
    public static class FabricSeed
    {
        public static void DataSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fabric>().HasData(
                 new Fabric
                 {
                     FabricId = 1,
                     FabricType = "Cotton",
                     Color = "White",
                     Pattern = "Plain",
                     Thickness = 5,
                     Durability = "High",
                     CostPerMeter = 25.5m
                 },
                 new Fabric
                 {
                     FabricId = 2,
                     FabricType = "Silk",
                     Color = "Red",
                     Pattern = "Floral",
                     Thickness = 2,
                     Durability = "Medium",
                     CostPerMeter = 50.75m
                 },
                 new Fabric
                 {
                     FabricId = 3,
                     FabricType = "Polyester",
                     Color = "Blue",
                     Pattern = "Striped",
                     Thickness = 3,
                     Durability = "High",
                     CostPerMeter = 15.0m
                 }

         );
        }
    }
}
