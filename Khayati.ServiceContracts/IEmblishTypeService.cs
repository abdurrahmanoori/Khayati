using Khayati.ServiceContracts.DTO;

namespace Khayati.ServiceContracts
{
    public interface IEmbellishmentmentTypeService
    {
        public Task<EmbellishmentmentTypeAddDto> AddEmbellishmentmentType(EmbellishmentmentTypeAddDto addEmbellishmentmentTypeDto);
        public Task<EmbellishmentmentTypeResponseDto> GetEmbellishmentmentTypeById(int? EmbellishmentmentTypeId);

        public Task<IEnumerable<EmbellishmentmentTypeResponseDto>> GetEmbellishmentmentTypeList();

        public Task<EmbellishmentmentTypeResponseDto> DeleteEmbellishmentmentType(int? EmbellishmentmentTypeId);
       // public Task<EmbellishmentmentTypeResponseDto> UpdateEmbellishmentmentType(int? EmbellishmentmentTypeId);

    }
}
