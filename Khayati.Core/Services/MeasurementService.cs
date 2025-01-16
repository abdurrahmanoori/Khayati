using AutoMapper;
using Entities;
using Khayati.Core.Common.Response;
using Khayati.Core.DTO;
using Khayati.Core.DTO.Measurements;
using Khayati.ServiceContracts;
using RepositoryContracts.Base;

namespace Khayati.Service
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MeasurementService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<MeasurementAddDto>> AddMeasurement(MeasurementAddDto MeasurementAddDto)
        {
            //Measurements Measurements = MeasurementAddDto.ToMeasurement();
            Measurement Measurement = _mapper.Map<Measurement>(MeasurementAddDto);

            await _unitOfWork.MeasurementRepository.Add(Measurement);
            await _unitOfWork.SaveChanges(CancellationToken.None);
            return Result<MeasurementAddDto>.SuccessResult(MeasurementAddDto);

        }

        public async Task<Result<MeasurementDto>>
            DeleteMeasurement(int MeasurementId)
        {
            Measurement? Measurement = await _unitOfWork.MeasurementRepository.GetById(MeasurementId);
            if (Measurement is null)
            {
                return Result<MeasurementDto>
                    .FailureResult(DeclareMessage.NotFound.Code, $"Measurement with ID {MeasurementId} not found.");
            }
            await _unitOfWork.MeasurementRepository.Remove(Measurement);
            await _unitOfWork.SaveChanges(default);
            var dto = _mapper.Map<MeasurementDto>(Measurement);
            return Result<MeasurementDto>.SuccessResult(dto);

        }

        public async Task<Result<MeasurementDto>>
            GetMeasurementById(int measurementId)
        {
            Measurement? measurement = await _unitOfWork.MeasurementRepository
                .GetFirstOrDefault(x => x.MeasurementId == measurementId);
            if (measurement is null)
            {
                return Result<MeasurementDto>
                   .FailureResult(DeclareMessage.NotFound.Code, $"Measurement with ID {measurementId} not found.");
            }

            MeasurementDto measurementDto =
                _mapper.Map<MeasurementDto>(measurement);

            return Result<MeasurementDto>.SuccessResult(measurementDto);

        }



        public async Task<Result<IEnumerable<MeasurementDto>>>
            GetMeasurementList( )
        {
            IEnumerable<Measurement> measurements =
              await _unitOfWork.MeasurementRepository
                .GetAll(includeProperties: "Customer");
            var measurmentDto = _mapper.Map<IEnumerable<MeasurementDto>>(measurements);

            if (measurements.Any() == false)
            {

                return Result<IEnumerable<MeasurementDto>>
                    .FailureResult(DeclareMessage.EmptyList.Code, DeclareMessage.EmptyList.Description);

            }

            return Result<IEnumerable<MeasurementDto>>.SuccessResult(measurmentDto);

        }

        public async Task<Result<MeasurementDto>>
            UpdateMeasurement(int measurementId, MeasurementDto measurementDto)
        {
            var measurement = await _unitOfWork
                .MeasurementRepository
                .GetFirstOrDefault(x => x.MeasurementId == measurementId);

            if (measurement == null)
            {
                return Result<MeasurementDto>
                    .FailureResult("NotFound", $"The Measurement with the provided {measurementId} ID was not found.");
            }

            _mapper.Map(measurementDto, measurement);
            measurement.MeasurementId = measurementId;
            await _unitOfWork.SaveChanges(CancellationToken.None);

            return Result<MeasurementDto>.SuccessResult(measurementDto);
        }    
    }
}
