using Khayati.Core.DTO.EmbellishmentType;

namespace Khayati.Core.DTO.Embellishment
{
    public class EmellishmentResponseDetailsDto
    {
        public int EmbellishmentId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Cost { get; set; }
        public bool? IsAcitve { get; set; }
        public int? EmbellishmentTypeId { get; set; }

        public EmbellishmentTypeAddDto EmbellishmentType { get; set; }
    }
}
