using Entities;
using Khayati.ServiceContracts;
using Khayati.Core.DTO;
using RepositoryContracts.Base;

namespace Khayati.Service
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MeasurementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MeasurementAddDto> AddMeasurement(MeasurementAddDto measurementAddDto)
        {
            if (measurementAddDto == null)
            {
                return null;
            }
            Measurement measurement = measurementAddDto.ToMeasurement();
            await _unitOfWork.MeasurementRepository.Add(measurement);
            await _unitOfWork.SaveChanges(CancellationToken.None);
            return measurementAddDto;

        }

        public async Task<MeasurementResponseDto> DeleteMeasurement(int? MeasurementId)
        {
            if (!MeasurementId.HasValue)
            {
                return null;
            }
            Measurement Measurement = await _unitOfWork.MeasurementRepository.GetById((int)MeasurementId);
            if (Measurement == null)
            {
                return null;
            }
            await _unitOfWork.MeasurementRepository.Remove(Measurement);
            await _unitOfWork.SaveChanges(default);

            return Measurement.ToMeasurementResponseDto();

        }


        public async Task<MeasurementResponseDto> GetMeasurementById(int? MeasurementId)
        {
            if (MeasurementId == null || MeasurementId == 0)
            {
                return null;
            }
            Measurement Measurement = await _unitOfWork.MeasurementRepository
                .GetFirstOrDefault(x => x.Measurementid == MeasurementId);

            MeasurementResponseDto MeasurementResponseDto = Measurement.ToMeasurementResponseDto();
            return MeasurementResponseDto;

        }

        public async Task<IEnumerable<MeasurementResponseDto>> GetMeasurementList()
        {
            IEnumerable<Measurement> Measurements = await _unitOfWork.MeasurementRepository.GetAll();
            if (Measurements is null)
            {
                return null;
            }

            IEnumerable<MeasurementResponseDto> MeasurementResponseDtos = Measurements
                .Select(temp => temp.ToMeasurementResponseDto());

            return MeasurementResponseDtos;

        }

    }
}
