namespace Khayati.Core.DTO.Measurement
{
    public class MeasurementDto
    {

        public int MeasurementId { get; set; }
        public decimal? Cost { get; set; }
        // public DateTime DateTaken { get; set; }
        public double Height { get; set; }
        public double ArmLength { get; set; }
        public double Sleeve { get; set; }
        public double ShoulderWidth { get; set; }
        public double Neck { get; set; }
        public double Chest { get; set; }
        public double Waist { get; set; }
        public double trousers { get; set; }
        public double Leg { get; set; }
        public int? FabricId { get; set; }
        public int CustomerId { get; set; }
    }
}

