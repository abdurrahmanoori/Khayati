using Khayati.Core.DTO.GarmentField;

namespace Khayati.Core.DTO
{
    public class GarmentAddDto
    {
        public string Name { get; set; } = string.Empty;

        public int Cost { get; set; }

        public ICollection<GarmentFieldAddDto> GarmentFields { get; set; } = new List<GarmentFieldAddDto>();
    }
}
