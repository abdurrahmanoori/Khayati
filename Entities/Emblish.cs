using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public  class Emblish
    {
        [Key]
        public int EmblishId { get; set; }

        public string EmblishName { get; set; }

        public int? EmblishTypeId { get; set; }


        public virtual EmblishType? EmblishType { get; set; }

        //public virtual ICollection<OrderEmbellish>? OrderEmbellishes { get; set; }
    }
}
