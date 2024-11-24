using Khayati.Core.DTO.Relative;

namespace Khayati.ServiceContracts
{
    public interface IRelativeService
    {
        public Task<RelativeAddDto> AddRelative(RelativeAddDto addRelativeDto);
        public Task<RelativeResponseDto> GetRelativeById(int? RelativeId);

        public Task<IEnumerable<RelativeResponseDto>> GetRelativeList();

        public Task<RelativeResponseDto> DeleteRelative(int? RelativeId);

    }
}
