using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class EmbellishmentmentType
    {
        [Key]
        public int EmbellishmentmentTypeId { get; set; }

        public string EmbellishmentmentTypeName { get;set; }
        public string? EmbellishmentmentTypeDiscription { get;set; }

        public virtual ICollection<Embellishmentment>? Embellishmentmentes { get; set; }

    }
}
