using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.Core.DTO
{
    public class EmbellishmentResponseDto
    {
        public int EmbellishmentId { get; set; }
        public string EmbellishmentName { get; set; }

        public string EmbellishmentDiscription { get; set; }
    }

    public static class EmbellishmentExtention
    {
        public static EmbellishmentResponseDto ToEmbellishmentResponseDto(this Embellishment Embellishmentr)
        {
            return new EmbellishmentResponseDto
            {
                EmbellishmentId = Embellishmentr.EmbellishmentId,
                EmbellishmentName = Embellishmentr.Name,
                EmbellishmentDiscription = Embellishmentr.Discription,
            };
        }
    }
}
