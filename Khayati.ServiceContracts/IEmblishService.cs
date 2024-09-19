using Khayati.ServiceContracts.DTO;

namespace Khayati.ServiceContracts
{
    public interface IEmbellishmentmentService
    {
        public Task<EmbellishmentmentAddDto> AddEmbellishmentment(EmbellishmentmentAddDto addEmbellishmentmentDto);
        public Task<EmbellishmentmentResponseDto> GetEmbellishmentmentById(int? EmbellishmentmentId);

        public Task<IEnumerable<EmbellishmentmentResponseDto>> GetEmbellishmentmentList();

        public Task<EmbellishmentmentResponseDto> DeleteEmbellishmentment(int? EmbellishmentmentId);
        // public Task<EmbellishmentmentResponseDto> UpdateEmbellishmentment(int? EmbellishmentmentId);

    }
}
