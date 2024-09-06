using Khayati.ServiceContracts.DTO;

namespace Khayati.ServiceContracts
{
    public interface IEmblishTypeService
    {
        public Task<EmblishTypeAddDto> AddEmblishType(EmblishTypeAddDto addEmblishTypeDto);
        public Task<EmblishTypeResponseDto> GetEmblishTypeById(int? EmblishTypeId);

        public Task<IEnumerable<EmblishTypeResponseDto>> GetEmblishTypeList();

        public Task<EmblishTypeResponseDto> DeleteEmblishType(int? EmblishTypeId);
       // public Task<EmblishTypeResponseDto> UpdateEmblishType(int? EmblishTypeId);

    }
}
