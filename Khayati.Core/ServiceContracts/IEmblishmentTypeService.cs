using Khayati.Core.DTO;
using Khayati.Core.DTO.EmbellishmentTypeDto;

namespace Khayati.ServiceContracts
{
    public interface IEmbellishmentTypeService
    {
        public Task<EmbellishmentTypeAddDto> AddEmbellishmentType(EmbellishmentTypeAddDto addEmbellishmentTypeDto);
        public Task<EmbellishmentTypeResponseDto> UpdateEmbellishmentType(EmbellishmentTypeResponseDto embellishmentTypeResponseDto);
        public Task<EmbellishmentTypeResponseDto> GetEmbellishmentTypeById(int? EmbellishmentTypeId);

        public Task<IEnumerable<EmbellishmentTypeResponseDto>> GetEmbellishmentTypeList();

        public Task<EmbellishmentTypeResponseDto> DeleteEmbellishmentType(int? EmbellishmentTypeId);
       // public Task<EmbellishmentTypeResponseDto> UpdateEmbellishmentType(int? EmbellishmentTypeId);

    }
}
