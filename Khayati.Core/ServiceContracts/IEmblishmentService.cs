using Khayati.Core.DTO;

namespace Khayati.ServiceContracts
{
    public interface IEmbellishmentService
    {
        public Task<EmbellishmentAddDto> AddEmbellishment(EmbellishmentAddDto addEmbellishmentDto);
        public Task<EmbellishmentResponseDto> GetEmbellishmentById(int? EmbellishmentId);
        public Task<EmbellishmentDetailDto> GetEmbellishmentDetails(int? EmbellishmentId);

        public Task<IEnumerable<EmbellishmentResponseDto>> GetEmbellishmentList();

        public Task<EmbellishmentResponseDto> DeleteEmbellishment(int? EmbellishmentId);
        // public Task<EmbellishmentResponseDto> UpdateEmbellishment(int? EmbellishmentId);

    }
}
