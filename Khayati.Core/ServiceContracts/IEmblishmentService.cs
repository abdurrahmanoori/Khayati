using Khayati.Core.Common.Response;
using Khayati.Core.DTO;
using Khayati.Core.DTO.Embellishments;

namespace Khayati.ServiceContracts
{
    public interface IEmbellishmentService
    {
        public Task<Result<EmbellishmentAddDto>> AddEmbellishment(EmbellishmentAddDto addEmbellishmentDto);
        public Task<Result<EmbellishmentResponseDto>> GetEmbellishmentById(int EmbellishmentId);
        public Task<Result<EmbellishmentDetailDto>> GetEmbellishmentDetails(int EmbellishmentId);
        public Task<Result<IEnumerable<EmellishmentResponseDetailsDto>>> GetEmbellishmentList();

        public Task<Result<EmbellishmentResponseDto>> DeleteEmbellishment(int EmbellishmentId);

        public Task<Result<bool>> Update(int embellishmentId, EmbellishmentUpdateDto updateDto);
        // public Task<EmbellishmentResponseDto> UpdateEmbellishment(int? EmbellishmentId);

    }
}
