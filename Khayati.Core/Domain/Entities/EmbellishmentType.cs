using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class EmbellishmentType
    {
        [Key]
        public int EmbellishmentTypeId { get; set; }

        public string Name { get;set; }
        public string? Description { get;set; }
        public short? SortOrder { get; set; }
        public virtual ICollection<Embellishment>? Embellishmentes { get; set; }

    }
}
