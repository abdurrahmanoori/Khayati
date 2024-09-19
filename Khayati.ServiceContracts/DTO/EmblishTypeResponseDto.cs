using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.ServiceContracts.DTO
{
    public class EmbellishmentmentTypeResponseDto
    {
        public int EmbellishmentmentTypeId { get; set; }
        public string EmbellishmentmentTypeName { get; set; }

        public string EmbellishmentmentTypeDiscription { get; set; }
    }

    public static class EmbellishmentmentTypeExtention
    {
        public static EmbellishmentmentTypeResponseDto ToEmbellishmentmentTypeResponseDto(this EmbellishmentmentType EmbellishmentmentType)
        {
            return new EmbellishmentmentTypeResponseDto
            {
                EmbellishmentmentTypeId = EmbellishmentmentType.EmbellishmentmentTypeId,
                EmbellishmentmentTypeName = EmbellishmentmentType.EmbellishmentmentTypeName,
                EmbellishmentmentTypeDiscription = EmbellishmentmentType.EmbellishmentmentTypeDiscription,
            };
        }
    }
}
