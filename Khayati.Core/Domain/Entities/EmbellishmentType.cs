using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class EmbellishmentType
    {
        [Key]
        public int EmbellishmentTypeId { get; set; }

        public string EmbellishmentTypeName { get;set; }
        public string? EmbellishmentTypeDiscription { get;set; }
        public short? SortOrder { get; set; }
        public virtual ICollection<Embellishment>? Embellishmentes { get; set; }

    }
}
