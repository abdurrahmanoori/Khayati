using Entities;

namespace Khayati.Core.DTO
{
    public class MeasurementAddDto
    {
        //public int CustomerId { get; set; }
        public double Height { get; set; }
        public double Chest { get; set; }
        public double Waist { get; set; }
        public double Leg { get; set; }
        public double trousers { get; set; }
        public double Neck { get; set; }
        public double Sleeve { get; set; }
        public double DateCreated { get; set; }
        public double DateTaken { get; set; }
       
        public double ShoulderWidth { get; set; }
        public double ArmLength { get; set; }
        public int CustomerId { get; set; }


        //public Measurement ToMeasurement()
        //{
        //    return new Measurement
        //    {

        //        //CustomerId = CustomerId,
        //        Height = Height,
        //        Chest = Chest,
        //        Waist = Waist,
        //        Sleeve = Sleeve,
        //        Neck = Neck,
        //        trousers = trousers,
        //        Leg = Leg,  
        //        ShoulderWidth = ShoulderWidth,  
        //        ArmLength = ArmLength,


        //    };
        //}

    }
}
