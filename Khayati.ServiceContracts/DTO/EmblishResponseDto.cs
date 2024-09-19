using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.ServiceContracts.DTO
{
    public class EmbellishmentmentResponseDto
    {
        public int EmbellishmentmentId { get; set; }
        public string EmbellishmentmentName { get; set; }

        public string EmbellishmentmentDiscription { get; set; }
    }

    public static class EmbellishmentmentExtention
    {
        public static EmbellishmentmentResponseDto ToEmbellishmentmentResponseDto(this Embellishmentment Embellishmentmentr)
        {
            return new EmbellishmentmentResponseDto
            {
                EmbellishmentmentId = Embellishmentmentr.EmbellishmentmentId,
                EmbellishmentmentName = Embellishmentmentr.EmbellishmentmentName,
                EmbellishmentmentDiscription = Embellishmentmentr.EmbellishmentmentDiscription,
            };
        }
    }
}
