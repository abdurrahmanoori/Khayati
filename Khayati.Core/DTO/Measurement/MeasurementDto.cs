namespace Khayati.Core.DTO.Measurements
{
    public class MeasurementDto
    {
        public int MeasurementId { get; set; }

        public int? GarmentId { get; set; }

        public int? Cost { get; set; }

        public double? Height { get; set; }
        public double? ArmLength { get; set; }
        public double? Sleeve { get; set; }
        public double? ShoulderWidth { get; set; }
        public double? Neck { get; set; }
        public double? Chest { get; set; }
        public double? Waist { get; set; }
        public double? Trousers { get; set; }
        public double? Leg { get; set; }

        // Extended measurements
        public double? Hip { get; set; }
        public double? Inseam { get; set; }
        public double? Thigh { get; set; }
        public double? Knee { get; set; }
        public double? Bicep { get; set; }
        public double? Wrist { get; set; }
        public double? Ankle { get; set; }
        public double? Bust { get; set; }
        public double? UnderBust { get; set; }
        public double? BackWidth { get; set; }
        public double? FrontLength { get; set; }
        public double? TorsoLength { get; set; }
        public double? SkirtLength { get; set; }
        public double? ShoulderToBust { get; set; }
        public double? ShoulderToWaist { get; set; }
        public double? WaistToHip { get; set; }
        public double? WaistToFloor { get; set; }
        public double? Armhole { get; set; }
        public double? Calf { get; set; }
        public double? NeckToWaist { get; set; }

        public int CustomerId { get; set; }

        public string? Description { get; set; }

        // Optional: include customer details if needed
        // public CustomerDto? Customer { get; set; }
    }
}
