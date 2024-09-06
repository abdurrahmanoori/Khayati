using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class EmblishType
    {
        [Key]
        public int EmblishTypeId { get; set; }

        public string EmblishTypeName { get;set; }
        public string? EmblishTypeDiscription { get;set; }

        [NotMapped]
        public virtual ICollection<Emblish>? Emblishes { get; set; }

    }
}
