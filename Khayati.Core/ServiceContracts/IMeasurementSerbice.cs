using Khayati.ServiceContracts.DTO;

namespace Khayati.ServiceContracts
{
    public interface IMeasurementService
    {
        public Task<MeasurementAddDto> AddMeasurement(MeasurementAddDto addMeasurementDto);
        public Task<MeasurementResponseDto> GetMeasurementById(int? MeasurementId);

        public Task<IEnumerable<MeasurementResponseDto>> GetMeasurementList();

        public Task<MeasurementResponseDto> DeleteMeasurement(int? MeasurementId);

    }
}
