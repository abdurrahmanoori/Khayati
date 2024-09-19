using Entities;

namespace Khayati.ServiceContracts.DTO
{
    public class EmbellishmentmentAddDto
    {

        public int EmbellishmentmentTypeId { get; set; }
        public string EmbellishmentmentName { get; set; }

        public string EmbellishmentmentDescription { get; set; }


        public Embellishmentment ToEmbellishmentment()
        {
            return new Embellishmentment
            {
                EmbellishmentmentName = EmbellishmentmentName,
                EmbellishmentmentDiscription = EmbellishmentmentDescription,
                EmbellishmentmentTypeId = EmbellishmentmentTypeId
            };
        }

    }
}
