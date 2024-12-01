using Khayati.Core.Common.Response;
using Khayati.Core.DTO;
using Khayati.Core.DTO.Embellishments;

namespace Khayati.ServiceContracts
{
    public interface IMeasurementService
    {
        public Task<Result<MeasurementAddDto>> 
            AddMeasurement(MeasurementAddDto addMeasurementDto);
        public Task<Result<MeasurementResponseDto>>
            GetMeasurementById(int MeasurementId);

        //public Task<Result<MeasurementDetailDto>> 
        //    GetMeasurementDetails(int MeasurementId);

        public Task<Result<IEnumerable<MeasurementResponseDetailsDto>>> 
            GetMeasurementList();

        public Task<Result<MeasurementResponseDto>>
            DeleteMeasurement(int MeasurementId);

        public Task<Result<MeasurementUpdateDto>>
            Update(int MeasurementId, MeasurementUpdateDto updateDto);
        // public Task<MeasurementResponseDto> UpdateMeasurement(int? MeasurementId);

    }
}
