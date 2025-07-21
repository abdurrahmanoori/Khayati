using Khayati.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.Infrastructure.DatabaseSeeders
{
    public static class GarmentSeed
    {
        public static void DataSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Garment>().HasData(
                new Garment
                {
                    GarmentId = 1,
                    Name = "Men's Shirt",
                    Cost = 1500
                },
                new Garment
                {
                    GarmentId = 2,
                    Name = "Women's Blouse",
                    Cost = 1800
                },
                new Garment
                {
                    GarmentId = 3,
                    Name = "Men's Trousers",
                    Cost = 2000
                },
                new Garment
                {
                    GarmentId = 4,
                    Name = "Women's Skirt",
                    Cost = 1700
                },
                new Garment
                {
                    GarmentId = 5,
                    Name = "Unisex Jacket",
                    Cost = 2500
                }
            );
        }
    }

}
