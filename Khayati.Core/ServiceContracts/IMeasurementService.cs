using Khayati.Core.Common.Response;
using Khayati.Core.DTO.Measurements;

namespace Khayati.ServiceContracts
{
    public interface IMeasurementService
    {
        public Task<Result<MeasurementAddDto>> 
            AddMeasurement(MeasurementAddDto measurementAddDto);

        public Task<Result<MeasurementDto>>
            GetMeasurementById(int measurementId);

        //public Task<Result<MeasurementDetailDto>> 
        //    GetMeasurementDetails(int MeasurementId);

        public Task<Result<IEnumerable<MeasurementDto>>> 
            GetMeasurementList();

        public Task<Result<MeasurementDto>>
            DeleteMeasurement(int measurementId);

        public Task<Result<MeasurementDto>>
            UpdateMeasurement(int measurementId, MeasurementDto updateDto);
        // public Task<MeasurementResponseDto> UpdateMeasurement(int? MeasurementId);

    }
}
