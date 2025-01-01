using AutoMapper;
using Entities;
using Khayati.Core.Common.Response;
using Khayati.Core.DTO;
using Khayati.Core.DTO.Embellishments;
using Khayati.ServiceContracts;
using RepositoryContracts.Base;

namespace Khayati.Service
{
    public class EmbellishmentService : IEmbellishmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmbellishmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<EmbellishmentAddDto>> AddEmbellishment(EmbellishmentAddDto embellishmentAddDto)
        {
            //Embellishment Embellishment = embellishmentAddDto.ToEmbellishment();
            Embellishment embellishment = _mapper.Map<Embellishment>(embellishmentAddDto);

            await _unitOfWork.EmbellishmentRepository.Add(embellishment);
            await _unitOfWork.SaveChanges(CancellationToken.None);
            return Result<EmbellishmentAddDto>.SuccessResult(embellishmentAddDto);

        }

        public async Task<Result<EmbellishmentResponseDto>>
            DeleteEmbellishment(int embellishmentId)
        {
            Embellishment embellishment = await _unitOfWork.EmbellishmentRepository.GetById(embellishmentId);
            if (embellishment is null)
            {
                return Result<EmbellishmentResponseDto>
                    .FailureResult(DeclareMessage.NotFound.Code, $"Ebellishment with ID {embellishmentId} not found.");
            }
            await _unitOfWork.EmbellishmentRepository.Remove(embellishment);
            await _unitOfWork.SaveChanges(default);
            var dto = _mapper.Map<EmbellishmentResponseDto>(embellishment);
            return Result<EmbellishmentResponseDto>.SuccessResult(dto);

        }


        public async Task<Result<EmbellishmentResponseDto>>
            GetEmbellishmentById(int embellishmentId)
        {
            Embellishment embellishment = await _unitOfWork.EmbellishmentRepository
                .GetFirstOrDefault(x => x.EmbellishmentId == embellishmentId);
            if (embellishment is null)
            {
                return Result<EmbellishmentResponseDto>
                   .FailureResult(DeclareMessage.NotFound.Code, $"Ebellishment with ID {embellishmentId} not found.");
            }

            EmbellishmentResponseDto embellishmentResponseDto =
                _mapper.Map<EmbellishmentResponseDto>(embellishment);

            return Result<EmbellishmentResponseDto>.SuccessResult(embellishmentResponseDto);

        }

        public async Task<Result<EmbellishmentDetailDto>>
            GetEmbellishmentDetails(int embellishmentId)
        {
            var query = (
                from e in await _unitOfWork.EmbellishmentRepository.GetAll()
                join et in await _unitOfWork.EmbellishmentTypeRepository.GetAll() 
                on e.EmbellishmentTypeId equals et.EmbellishmentTypeId
                where e.EmbellishmentId == embellishmentId
                select new EmbellishmentDetailDto
                {
                    EmbellishmentId = e.EmbellishmentId,
                    Name = e.Name,
                    EmbellishmentTypeName = et.Name,
                    EmbellishmentTypeId = et.EmbellishmentTypeId,
                }).FirstOrDefault();
            if (query is null)
            {
                return Result<EmbellishmentDetailDto>
                   .FailureResult(DeclareMessage.NotFound.Code, $"Embellishment with ID {embellishmentId} not found.");
            }

            return Result<EmbellishmentDetailDto>.SuccessResult(query);
        }

        public async Task<Result<IEnumerable<EmellishmentResponseDetailsDto>>>
            GetEmbellishmentList( )
        {
            IEnumerable<EmellishmentResponseDetailsDto> embellishments =
              await _unitOfWork.EmbellishmentRepository
                .GetEmellishmentResponseDetailList();

            if (embellishments.Any() == false)
            {

                return Result<IEnumerable<EmellishmentResponseDetailsDto>>
                    .FailureResult(DeclareMessage.EmptyList.Code, DeclareMessage.EmptyList.Description);

            }

            return Result<IEnumerable<EmellishmentResponseDetailsDto>>.SuccessResult(embellishments);

        }

        public async Task<Result<EmbellishmentUpdateDto>>
            Update(int embellishmentId, EmbellishmentUpdateDto updateDto)
        {
            var embellishment = await _unitOfWork
                .EmbellishmentRepository
                .GetFirstOrDefault(x => x.EmbellishmentId == embellishmentId);

            if (embellishment == null)
            {
                return Result<EmbellishmentUpdateDto>
                    .FailureResult("NotFound", $"The embellishment with the provided {embellishmentId} ID was not found.");
            }

            _mapper.Map(updateDto, embellishment);
            embellishment.EmbellishmentId = embellishmentId;
            await _unitOfWork.SaveChanges(CancellationToken.None);

            return Result<EmbellishmentUpdateDto>.SuccessResult(updateDto);
        }
        //public Task<Result<string>> Update(EmbellishmentUpdateDto updateDto)
        //{
        //    return Result<bool>.FailureResult()
        //    return Task.FromResult(Result<string>.SuccessResult("not found"));
        //}
    }
}
