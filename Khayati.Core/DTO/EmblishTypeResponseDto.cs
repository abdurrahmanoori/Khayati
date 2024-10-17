using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.Core.DTO
{
    public class EmbellishmentTypeResponseDto
    {
        public int EmbellishmentTypeId { get; set; }
        public string Name { get; set; }
        public short? SortOrder { get; set; }
        public string Discription { get; set; }
    }

    public static class EmbellishmentTypeExtention
    {
        public static EmbellishmentTypeResponseDto ToEmbellishmentTypeResponseDto(this EmbellishmentType EmbellishmentType)
        {
            return new EmbellishmentTypeResponseDto
            {
                EmbellishmentTypeId = EmbellishmentType.EmbellishmentTypeId,
                Name = EmbellishmentType.Name,
                SortOrder = EmbellishmentType.SortOrder,
                Discription = EmbellishmentType.Discription,
            };
        }
    }
}
