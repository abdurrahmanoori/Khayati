
using Khayati.Core.DTO.GarmentField;

namespace Khayati.Core.DTO.Garments
{
    public class GarmentDto
    {
        public int GarmentId { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Cost { get; set; }

        public ICollection<GarmentFieldAddDto> GarmentFields { get; set; } = new List<GarmentFieldAddDto>();
    }
}
