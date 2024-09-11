using Entities;

namespace Khayati.ServiceContracts.DTO
{
    public class MeasurementAddDto
    {
        public int CustomerId { get; set; }
        public DateTime DateTaken { get; set; }
        public double Height { get; set; }
        public double Chest { get; set; }
        public double Waist { get; set; }
        public double Hip { get; set; }
        public double ShoulderWidth { get; set; }
        public double ArmLength { get; set; }
        public double Inseam { get; set; }


        public Measurement ToMeasurement()
        {
            return new Measurement
            {
                
                CustomerId = CustomerId,
                DateTaken = DateTaken,  
                Height = Height,
                Chest = Chest,
                Waist = Waist,  
                Hip = Hip,  
                ShoulderWidth = ShoulderWidth,  
                ArmLength = ArmLength,
                Inseam = Inseam
                
            };
        }

    }
}
