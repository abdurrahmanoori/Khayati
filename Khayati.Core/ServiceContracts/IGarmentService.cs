using Khayati.Core.Common.Response;
using Khayati.Core.DTO;
using Khayati.Core.DTO.Garments;

namespace Khayati.ServiceContracts
{
    public interface IGarmentService
    {
        Task<Result<GarmentDto>> AddGarment(GarmentAddDto dto);
        Task<Result<bool>> UpdateGarment(int id, GarmentDto dto);
        Task<Result<GarmentDto>> GetGarmentById(int id);
        Task<Result<List<GarmentDto>>> GetGarmentList( );
        Task<Result<bool>> DeleteGarment(int id);

    }
}
