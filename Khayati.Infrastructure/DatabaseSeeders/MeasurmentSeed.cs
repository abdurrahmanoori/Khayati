using Entities;
using Microsoft.EntityFrameworkCore;

namespace Khayati.Infrastructure.DatabaseSeeders
{
    public static class MeasurmentSeed
    {
        public static void DataSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Measurement>().HasData(

                 new Measurement
                 {
                     MeasurementId = 1,
                     CustomerId = 1,
                     //DateTaken = new DateTime(2024, 10, 01),
                     Height = 175.5, // Example height in centimeters
                     ArmLength = 62, // Example arm length in centimeters
                     Sleeve = 60, // Example sleeve length in centimeters
                     ShoulderWidth = 45, // Example shoulder width in centimeters
                     Neck = 38, // Example neck measurement in centimeters
                     Chest = 100, // Example chest measurement in centimeters
                     Waist = 80, // Example waist measurement in centimeters
                     //Trousers = 90, // Example trousers length in centimeters
                     Leg = 80, // Example leg length in centimeters
                     CreatedAt = DateTime.Now, // Current date for when the measurement was created
                    //FabricId = 
                 },
            new Measurement
            {
                MeasurementId = 2,
                CustomerId = 2,
                //DateTaken = new DateTime(2024, 10, 02),
                Height = 176.0,
                ArmLength = 63,
                Sleeve = 61,
                ShoulderWidth = 46,
                Neck = 39,
                Chest = 101,
                Waist = 81,
                //Trousers = 91,
                Leg = 81,
                CreatedAt = DateTime.Now
            },
            new Measurement
            {
                MeasurementId = 3,
                CustomerId = 3,
                //DateTaken = new DateTime(2024, 10, 03),
                Height = 175.5,
                ArmLength = 62.5,
                Sleeve = 60.5,
                ShoulderWidth = 45,
                Neck = 38.5,
                Chest = 99,
                Waist = 79,
                //Trousers = 89,
                Leg = 79,
                CreatedAt = DateTime.Now
            },
            new Measurement
            {
                MeasurementId = 4,
                CustomerId = 4,
                //DateTaken = new DateTime(2024, 10, 04),
                Height = 177.0,
                ArmLength = 64,
                Sleeve = 62,
                ShoulderWidth = 46,
                Neck = 40,
                Chest = 102,
                Waist = 82,
                //Trousers = 92,
                Leg = 82,
                CreatedAt = DateTime.Now
            }
        );
        }
    }
}
