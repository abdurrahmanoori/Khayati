﻿using Entities;

namespace Khayati.Core.DTO.Measurement
{
    public class MeasurementAddDto
    {
        //public int CustomerId { get; set; }
        public int Height { get; set; }
        public int Chest { get; set; }
        public int Waist { get; set; }
        public int Leg { get; set; }
        public int trousers { get; set; }
        public int Neck { get; set; }
        public int Sleeve { get; set; }
        public int DateCreated { get; set; }
        public int DateTaken { get; set; }

        public int ShoulderWidth { get; set; }
        public int ArmLength { get; set; }
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
