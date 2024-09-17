using Entities;

namespace Khayati.ServiceContracts.DTO
{
    public class EmbellishmentmentTypeAddDto
    {
        public string EmbellishmentmentTypeName { get; set; }

        public string EmbellishmentmentTypeDescription { get; set; }


        public EmbellishmentmentType ToEmbellishmentmentType()
        {
            return new EmbellishmentmentType
            {
                EmbellishmentmentTypeName = EmbellishmentmentTypeName,
                EmbellishmentmentTypeDiscription = EmbellishmentmentTypeDescription
            };
        }

    }
}
