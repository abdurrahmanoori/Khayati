using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class EmbellishmentType
    {
        [Key]
        public int EmbellishmentTypeId { get; set; }

        public string EmbellishmentTypeName { get;set; }
        public string? EmbellishmentTypeDiscription { get;set; }

        public virtual ICollection<Embellishment>? Embellishmentes { get; set; }

    }
}
