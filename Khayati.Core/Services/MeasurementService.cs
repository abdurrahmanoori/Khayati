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
            //Measurement Measurement = MeasurementAddDto.ToMeasurement();
            Measurement Measurement = _mapper.Map<Measurement>(MeasurementAddDto);

            await _unitOfWork.MeasurementRepository.Add(Measurement);
            await _unitOfWork.SaveChanges(CancellationToken.None);
            return Result<MeasurementAddDto>.SuccessResult(MeasurementAddDto);

        }

        public async Task<Result<MeasurementResponseDto>>
            DeleteMeasurement(int MeasurementId)
        {
            Measurement Measurement = await _unitOfWork.MeasurementRepository.GetById(MeasurementId);
            if (Measurement is null)
            {
                return Result<MeasurementResponseDto>
                    .FailureResult(DeclareMessage.NotFound.Code, $"Ebellishment with ID {MeasurementId} not found.");
            }
            await _unitOfWork.MeasurementRepository.Remove(Measurement);
            await _unitOfWork.SaveChanges(default);
            var dto = _mapper.Map<MeasurementResponseDto>(Measurement);
            return Result<MeasurementResponseDto>.SuccessResult(dto);

        }


        public async Task<Result<MeasurementResponseDto>>
            GetMeasurementById(int MeasurementId)
        {
            Measurement Measurement = await _unitOfWork.MeasurementRepository
                .GetFirstOrDefault(x => x.MeasurementId == MeasurementId);
            if (Measurement is null)
            {
                return Result<MeasurementResponseDto>
                   .FailureResult(DeclareMessage.NotFound.Code, $"Ebellishment with ID {MeasurementId} not found.");
            }

            MeasurementResponseDto MeasurementResponseDto =
                _mapper.Map<MeasurementResponseDto>(Measurement);

            return Result<MeasurementResponseDto>.SuccessResult(MeasurementResponseDto);

        }

        public async Task<Result<MeasurementDetailDto>>
            GetMeasurementDetails(int MeasurementId)
        {
            var query = (
                from e in await _unitOfWork.MeasurementRepository.GetAll()
                join et in await _unitOfWork.MeasurementTypeRepository.GetAll() 
                on e.MeasurementTypeId equals et.MeasurementTypeId
                where e.MeasurementId == MeasurementId
                select new MeasurementDetailDto
                {
                    MeasurementId = e.MeasurementId,
                    Name = e.Name,
                    MeasurementTypeName = et.Name,
                    MeasurementTypeId = et.MeasurementTypeId,
                }).FirstOrDefault();
            if (query is null)
            {
                return Result<MeasurementDetailDto>
                   .FailureResult(DeclareMessage.NotFound.Code, $"Measurement with ID {MeasurementId} not found.");
            }

            return Result<MeasurementDetailDto>.SuccessResult(query);
        }

        public async Task<Result<IEnumerable<EmellishmentResponseDetailsDto>>>
            GetMeasurementList( )
        {
            IEnumerable<EmellishmentResponseDetailsDto> Measurements =
              await _unitOfWork.MeasurementRepository
                .GetEmellishmentResponseDetailList();

            if (Measurements.Any() == false)
            {

                return Result<IEnumerable<EmellishmentResponseDetailsDto>>
                    .FailureResult(DeclareMessage.EmptyList.Code, DeclareMessage.EmptyList.Description);

            }

            return Result<IEnumerable<EmellishmentResponseDetailsDto>>.SuccessResult(Measurements);

        }

        public async Task<Result<MeasurementUpdateDto>>
            Update(int MeasurementId, MeasurementUpdateDto updateDto)
        {
            var Measurement = await _unitOfWork
                .MeasurementRepository
                .GetFirstOrDefault(x => x.MeasurementId == MeasurementId);

            if (Measurement == null)
            {
                return Result<MeasurementUpdateDto>
                    .FailureResult("NotFound", $"The Measurement with the provided {MeasurementId} ID was not found.");
            }

            _mapper.Map(updateDto, Measurement);
            Measurement.MeasurementId = MeasurementId;
            await _unitOfWork.SaveChanges(CancellationToken.None);

            return Result<MeasurementUpdateDto>.SuccessResult(updateDto);
        }

        Task<Result<IEnumerable<MeasurementResponseDetailsDto>>> IMeasurementService.GetMeasurementList( )
        {
            throw new NotImplementedException();
        }
        //public Task<Result<string>> Update(MeasurementUpdateDto updateDto)
        //{
        //    return Result<bool>.FailureResult()
        //    return Task.FromResult(Result<string>.SuccessResult("not found"));
        //}
    }
}
