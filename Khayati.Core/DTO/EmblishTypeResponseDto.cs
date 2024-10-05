using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.ServiceContracts.DTO
{
    public class EmbellishmentTypeResponseDto
    {
        public int EmbellishmentTypeId { get; set; }
        public string EmbellishmentTypeName { get; set; }

        public string EmbellishmentTypeDiscription { get; set; }
    }

    public static class EmbellishmentTypeExtention
    {
        public static EmbellishmentTypeResponseDto ToEmbellishmentTypeResponseDto(this EmbellishmentType EmbellishmentType)
        {
            return new EmbellishmentTypeResponseDto
            {
                EmbellishmentTypeId = EmbellishmentType.EmbellishmentTypeId,
                EmbellishmentTypeName = EmbellishmentType.EmbellishmentTypeName,
                EmbellishmentTypeDiscription = EmbellishmentType.EmbellishmentTypeDiscription,
            };
        }
    }
}
