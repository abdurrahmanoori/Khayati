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
        public double Height { get; set; }
        public double Chest { get; set; }
        public double Waist { get; set; }
        public double Sleeve { get; set; }
        public double Neck { get; set; }
        public double trousers { get; set; }
        public double Leg { get; set; }
        
        public double ShoulderWidth { get; set; }
        public double ArmLength { get; set; }
        
    }

    public static class MeasurementExtention
    {
        public static MeasurementResponseDto ToMeasurementResponseDto(this Measurement Measurement)
        {
            return new MeasurementResponseDto
            {
                MeasurementID = Measurement.Measurementid,
                CustomerID = Measurement.CustomerId,
                Height = Measurement.Height,
                Chest = Measurement.Chest,
                ArmLength = Measurement.ArmLength,
                ShoulderWidth = Measurement.ShoulderWidth,
                Waist = Measurement.Waist,
                Sleeve = Measurement.Sleeve,
                Neck = Measurement.Neck,
                trousers = Measurement.trousers,
                Leg = Measurement.Leg

            };
        }
    }
}
