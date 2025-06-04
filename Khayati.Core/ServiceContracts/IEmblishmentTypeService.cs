using Khayati.Core.Common.Response;
using Khayati.Core.DTO.EmbellishmentType;

namespace Khayati.ServiceContracts
{
    public interface IEmbellishmentTypeService
    {
        public Task<Result<EmbellishmentTypeAddDto>> AddEmbellishmentType(EmbellishmentTypeAddDto addEmbellishmentTypeDto);
        public Task<Result<bool>> UpdateEmbellishmentType(int id,EmbellishmentTypeResponseDto embellishmentTypeResponseDto);
        public Task<Result< EmbellishmentTypeResponseDto>> GetEmbellishmentTypeById(int embellishmentTypeId);
        public Task<Result<IEnumerable<EmbellishmentTypeResponseDto>>> GetEmbellishmentTypeList();

        public Task<Result<bool>> DeleteEmbellishmentType(int embellishmentTypeId);
       // public Task<EmbellishmentTypeResponseDto> UpdateEmbellishmentType(int? EmbellishmentTypeId);

    }
}
