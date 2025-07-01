using Khayati.Core.Common.Response;
using Khayati.Core.DTO.Embellishment;

namespace Khayati.ServiceContracts
{
    public interface IEmbellishmentService
    {
        Task<Result<EmbellishmentAddDto>> AddEmbellishment(EmbellishmentAddDto dto);
        Task<Result<bool>> UpdateEmbellishment(int id, EmbellishmentUpdateDto dto);
        Task<Result<EmellishmentResponseDetailsDto>> GetEmbellishmentById(int id);
        Task<Result<IEnumerable<EmellishmentResponseDetailsDto>>> GetEmbellishmentList();
        Task<Result<bool>> DeleteEmbellishment(int id);
    }

}
