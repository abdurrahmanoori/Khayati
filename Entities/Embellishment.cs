using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public  class Embellishmentment
    {
        [Key]
        public int EmbellishmentmentId { get; set; }

        public string EmbellishmentmentName { get; set; }
        public string? EmbellishmentmentDiscription { get; set; }
        public int? Cost { get; set; }
        public int? EmbellishmentmentTypeId { get; set; }

        [ForeignKey(nameof(EmbellishmentmentTypeId))]
        public virtual EmbellishmentmentType? EmbellishmentmentType { get; set; }

        //public virtual ICollection<OrderEmbellishment>? OrderEmbellishmentes { get; set; }
    }
}
