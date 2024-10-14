using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public  class Embellishment
    {
        [Key]
        public int EmbellishmentId { get; set; }

        public string Name { get; set; }
        public string? Discription { get; set; }
        public int? Cost { get; set; }
        public int? EmbellishmentTypeId { get; set; }

        public bool? IsAcitve { get; set; }

        [ForeignKey(nameof(EmbellishmentTypeId))]
        public virtual EmbellishmentType? EmbellishmentType { get; set; }

        //public virtual ICollection<OrderEmbellishment>? OrderEmbellishmentes { get; set; }
    }
}
