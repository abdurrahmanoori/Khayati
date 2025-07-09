using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Khayati.Core.DTO.GarmentField
{
    public class GarmentFieldResponseDto
    {
        public int GarmentFieldId { get; set; }

        public int GarmentId { get; set; }

        public string? FieldName { get; set; }

        [ForeignKey(nameof(GarmentId))]
        public virtual Khayati.Core.Domain.Entities.Garment? Garment { get; set; }
    }
}
