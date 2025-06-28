using Khayati.Core.DTO.Customers;

namespace Khayati.Core.DTO.Measurements
{
    public class MeasurementDto
    {
        public int MeasurementId { get; set; }
        public int? Cost { get; set; }
        // public DateTime DateTaken { get; set; }
        public int? Height { get; set; }
        public int? ArmLength { get; set; }
        public int? Sleeve { get; set; }
        public int? ShoulderWidth { get; set; }
        public int? Neck { get; set; }
        public int? Chest { get; set; }
        public int? Waist { get; set; }
        public int? trousers { get; set; }
        public int? Leg { get; set; }
        public int? FabricId { get; set; }
        public int CustomerId { get; set; }
        //public CustomerDto? Customer { get; set; }
    }
}

