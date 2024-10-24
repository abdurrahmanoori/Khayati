using Entities;

namespace Khayati.Core.DTO
{
    public class EmbellishmentAddDto
    {

        public int EmbellishmentTypeId { get; set; }
        public string EmbellishmentName { get; set; }

        public string EmbellishmentDescription { get; set; }


        public Embellishment ToEmbellishment()
        {
            return new Embellishment
            {
                Name = EmbellishmentName,
                Description = EmbellishmentDescription,
                EmbellishmentTypeId = EmbellishmentTypeId
            };
        }

    }
}
