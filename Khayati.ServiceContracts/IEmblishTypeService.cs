using Khayati.ServiceContracts.DTO;

namespace Khayati.ServiceContracts
{
    public interface IEmbellishmentTypeService
    {
        public Task<EmbellishmentTypeAddDto> AddEmbellishmentType(EmbellishmentTypeAddDto addEmbellishmentTypeDto);
        public Task<EmbellishmentTypeResponseDto> GetEmbellishmentTypeById(int? EmbellishmentTypeId);

        public Task<IEnumerable<EmbellishmentTypeResponseDto>> GetEmbellishmentTypeList();

        public Task<EmbellishmentTypeResponseDto> DeleteEmbellishmentType(int? EmbellishmentTypeId);
       // public Task<EmbellishmentTypeResponseDto> UpdateEmbellishmentType(int? EmbellishmentTypeId);

    }
}
