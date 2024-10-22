using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using System.Threading.Tasks;

namespace Khayati.Core.DTO.EmbellishmentType
{
    public class EmbellishmentTypeResponseDto
    {
        public int EmbellishmentTypeId { get; set; }
        public string Name { get; set; }
        public short? SortOrder { get; set; }
        public string Description { get; set; }
    }

    public static class EmbellishmentTypeExtention
    {
        public static EmbellishmentTypeResponseDto ToEmbellishmentTypeResponseDto(this Entities.EmbellishmentType EmbellishmentType)
        {
            return new EmbellishmentTypeResponseDto
            {
                EmbellishmentTypeId = EmbellishmentType.EmbellishmentTypeId,
                Name = EmbellishmentType.Name,
                SortOrder = EmbellishmentType.SortOrder,
                Description = EmbellishmentType.Description,
            };
        }
    }
}
