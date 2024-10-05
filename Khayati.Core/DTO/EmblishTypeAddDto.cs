using Entities;

namespace Khayati.ServiceContracts.DTO
{
    public class EmbellishmentTypeAddDto
    {
        public string EmbellishmentTypeName { get; set; }

        public string EmbellishmentTypeDescription { get; set; }


        public EmbellishmentType ToEmbellishmentType()
        {
            return new EmbellishmentType
            {
                EmbellishmentTypeName = EmbellishmentTypeName,
                EmbellishmentTypeDiscription = EmbellishmentTypeDescription
            };
        }

    }
}
