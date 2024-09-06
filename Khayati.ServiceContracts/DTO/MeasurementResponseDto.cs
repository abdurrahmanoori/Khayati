using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.ServiceContracts.DTO
{
    public class MeasurementResponseDto
    {
        public int MeasurementID { get; set; }
        public int CustomerID { get; set; }
        public DateTime DateTaken { get; set; }
        public double Height { get; set; }
        public double Chest { get; set; }
        public double Waist { get; set; }
        public double Hip { get; set; }
        public double ShoulderWidth { get; set; }
        public double ArmLength { get; set; }
        public double Inseam { get; set; }
    }

    public static class MeasurementExtention
    {
        public static MeasurementResponseDto ToMeasurementResponseDto(this Measurement Measurement)
        {
            return new MeasurementResponseDto
            {
                MeasurementID = Measurement.MeasurementID,
                CustomerID = Measurement.CustomerId,
                DateTaken = Measurement.DateTaken,  
                Height = Measurement.Height,
                Chest = Measurement.Chest,
                ArmLength = Measurement.ArmLength,
                Hip = Measurement.Hip,
                Inseam = Measurement.Inseam,
                ShoulderWidth = Measurement.ShoulderWidth,
                Waist = Measurement.Waist
                
            };
        }
    }
}
