namespace Khayati.Core.DTO.Embellishment
{
    public class EmellishmentResponseDetailsDto
    {
        public int EmbellishmentId { get; set; }
        public string EmbellishmentName { get; set; } = string.Empty;

        public string? EmbellishmentDescription { get; set; } = string.Empty;

        public string EmbellishmentTypeName { get; set; } = string.Empty;
        public int EmbellishmentTypeId { get; set; }

        public int? Cost { get; set; }
    }
}
