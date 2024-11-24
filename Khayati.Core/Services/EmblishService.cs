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

        public async Task<EmbellishmentAddDto> AddEmbellishment(EmbellishmentAddDto embellishmentAddDto)
        {
            //var validator = new EmbellishmentResponseDetailsDtoValidator();
            //var result = await validator.ValidateAsync(embellishmentAddDto);

            //ValidationHelper.ModelValidation(embellishmentAddDto);

            if (embellishmentAddDto == null)
            {
                return null;
            }
            //Embellishment Embellishment = embellishmentAddDto.ToEmbellishment();
            Embellishment Embellishment = _mapper.Map<Embellishment>(embellishmentAddDto);

            await _unitOfWork.EmbellishmentRepository.Add(Embellishment);
            await _unitOfWork.SaveChanges(CancellationToken.None);
            return embellishmentAddDto;

        }

        public async Task<EmbellishmentResponseDto>
            DeleteEmbellishment(int? embellishmentId)
        {
            if (!embellishmentId.HasValue)
            {
                return null;
            }
            Embellishment embellishment = await _unitOfWork.EmbellishmentRepository.GetById((int)embellishmentId);
            if (embellishment == null)
            {
                return null;
            }
            await _unitOfWork.EmbellishmentRepository.Remove(embellishment);
            await _unitOfWork.SaveChanges(default);

            return embellishment.ToEmbellishmentResponseDto();

        }


        public async Task<EmbellishmentResponseDto>
            GetEmbellishmentById(int? EmbellishmentId)
        {
            if (EmbellishmentId == null || EmbellishmentId == 0)
            {
                return null;
            }
            Embellishment Embellishment = await _unitOfWork.EmbellishmentRepository
                .GetFirstOrDefault(x => x.EmbellishmentId == EmbellishmentId);

            EmbellishmentResponseDto EmbellishmentResponseDto = Embellishment.ToEmbellishmentResponseDto();
            return EmbellishmentResponseDto;

        }

        public async Task<EmbellishmentDetailDto>
            GetEmbellishmentDetails(int? EmbellishmentId)
        {
            var query = (
                from e in await _unitOfWork.EmbellishmentRepository.GetAll()
                join et in await _unitOfWork.EmbellishmentTypeRepository.GetAll() on e.EmbellishmentTypeId equals et.EmbellishmentTypeId
                select new EmbellishmentDetailDto
                {
                    EmbellishmentId = e.EmbellishmentId,
                    Name = e.Name,
                    EmbellishmentTypeName = et.Name,
                    EmbellishmentTypeId = et.EmbellishmentTypeId,
                }
                ).FirstOrDefault();
            return query;
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

        public async Task<Result<bool>>
            Update(int embellishmentId, EmbellishmentUpdateDto updateDto)
        {
            var embellishment = await _unitOfWork
                .EmbellishmentRepository
                .GetFirstOrDefault(x => x.EmbellishmentId == embellishmentId);

            if (embellishment == null)
            {
                return Result<bool>
                    .FailureResult("NotFound", $"The embellishment with the provided {embellishmentId} ID was not found.");
            }

            _mapper.Map(updateDto, embellishment);
            embellishment.EmbellishmentId = embellishmentId;
            await _unitOfWork.SaveChanges(CancellationToken.None);

            return Result<bool>.SuccessResult(true);
        }
        //public Task<Result<string>> Update(EmbellishmentUpdateDto updateDto)
        //{
        //    return Result<bool>.FailureResult()
        //    return Task.FromResult(Result<string>.SuccessResult("not found"));
        //}
    }
}
