namespace Khayati.Core.DTO.OrderDesign
{
    public class OrderDesignAddDto
    {
        public int CustomerId { get; set; }

        public int OrderId { get; set; }

        public decimal? Price { get; set; }
      
        public int MeasurementId { get; set; }
        public int? EmbellishmentId { get; set; }

        public string? ImageUrl { get; set; }
        public string? Notes { get; set; }
    }
}
