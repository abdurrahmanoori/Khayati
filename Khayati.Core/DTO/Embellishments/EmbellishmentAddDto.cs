using Entities;
using System.ComponentModel.DataAnnotations;

namespace Khayati.Core.DTO.Embellishment
{
    public class EmbellishmentAddDto
    {


        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Cost { get; set; }

        public int EmbellishmentTypeId { get; set; }
        public bool? IsAcitve { get; set; }





        public Entities.Embellishment ToEmbellishment()
        {
            return new Entities.Embellishment
            {
                // Name = EmbellishmentName,
                // Description = EmbellishmentDescription,
                EmbellishmentTypeId = EmbellishmentTypeId
            };
        }

    }
}
