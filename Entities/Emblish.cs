using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public  class Emblish
    {
        [Key]
        public int EmblishId { get; set; }

        public string EmblishName { get; set; }
        public string? EmblishDiscription { get; set; }
        public int? Cost { get; set; }
        public int? EmblishTypeId { get; set; }

        [ForeignKey(nameof(EmblishTypeId))]
        public virtual EmblishType? EmblishType { get; set; }

        //public virtual ICollection<OrderEmbellish>? OrderEmbellishes { get; set; }
    }
}
