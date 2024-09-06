using Entities;

namespace Khayati.ServiceContracts.DTO
{
    public class EmblishTypeAddDto
    {
        public string EmblishTypeName { get; set; }

        public string EmblishTypeDescription { get; set; }


        public EmblishType ToEmblishType()
        {
            return new EmblishType
            {
                EmblishTypeName = EmblishTypeName,
                EmblishTypeDiscription = EmblishTypeDescription
            };
        }

    }
}
