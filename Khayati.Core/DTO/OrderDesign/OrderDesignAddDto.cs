namespace Khayati.Core.DTO.OrderDesign
{
    public class OrderDesignAddDto
    {
        public int GarmentId { get; set; }
        public int CustomerId { get; set; }
        public int? FabricId { get; set; }
        public int OrderId { get; set; }
        public decimal? CostAtTimeOfOrder { get; set; }
        public int? MeasurementId { get; set; }
        public int? EmbellishmentId { get; set; }

        public string? Notes { get; set; }
    }
}
