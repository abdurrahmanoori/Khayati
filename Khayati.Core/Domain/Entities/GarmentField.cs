using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Khayati.Core.Domain.Entities
{   
    public class GarmentField
    {
        [Key]
        public int GarmentFieldId { get; set; }

        public int GarmentId { get; set; }

        public string? FieldName { get; set; }

        [ForeignKey(nameof(GarmentId))]
        public virtual Garment Garment { get; set; }
    }
}
