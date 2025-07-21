using Khayati.Core.DTO.Garments;
using Khayati.Core.DTO.OrderGarmentEmbellishments;

namespace Khayati.Core.DTO.OrderGarments
{
    public class OrderGarmentDto
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? GarmentId { get; set; }
        public int? Quantity { get; set; }
        public decimal? CostAtTimeOfOrder { get; set; }
        public bool? IsMainGarment { get; set; }
        public string? ProductionStatus { get; set; }
        public DateTime? CutDate { get; set; }
        public DateTime? ExpectedCompletionDate { get; set; }
        public string? Notes { get; set; }
        public int FabricId { get; set; }
        public decimal? FabricCostAtTimeOfOrder { get; set; }
        public float? FabricQuantityUsed { get; set; }

        public List<OrderGarmentEmbellishmentDto>? OrderGarmentEmbellishments { get; set; }
    }

}
