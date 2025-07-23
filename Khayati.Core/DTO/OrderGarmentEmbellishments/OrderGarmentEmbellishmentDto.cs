namespace Khayati.Core.DTO.OrderGarmentEmbellishments
{
    public class OrderGarmentEmbellishmentDto
    {
        public int? Id { get; set; }
        public int? OrderGarmentId { get; set; }
        public int EmbellishmentId { get; set; }
        public string? CustomInstructions { get; set; }
        public decimal? CostAtTimeOfOrder { get; set; }
        public int? AppliedBy { get; set; }

    }

}
