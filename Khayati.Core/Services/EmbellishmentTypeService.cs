using AutoMapper;
using Entities;
using Khayati.Core.Common.Response;
using Khayati.Core.DTO;
using Khayati.Core.DTO.EmbellishmentType;
using Khayati.ServiceContracts;
using RepositoryContracts.Base;

namespace Khayati.Service
{
    public class EmbellishmentTypeService : IEmbellishmentTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmbellishmentTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<EmbellishmentTypeAddDto>> AddEmbellishmentType(EmbellishmentTypeAddDto embellishmentTypeAddDto)
        {
            var embellishmentType = _mapper.Map<EmbellishmentType>(embellishmentTypeAddDto);

            await _unitOfWork.EmbellishmentTypeRepository.Add(embellishmentType);
            await _unitOfWork.SaveChanges();

            return Result<EmbellishmentTypeAddDto>.SuccessResult(_mapper.Map<EmbellishmentTypeAddDto>(embellishmentType));
        }

        public async Task<Result<bool>> DeleteEmbellishmentType(int embellishmentTypeId)
        {
            EmbellishmentType? embellishmentType = await _unitOfWork.EmbellishmentTypeRepository.GetById(embellishmentTypeId);
            if (embellishmentType == null)
                return Result<bool>.NotFoundResult(embellishmentTypeId);

            await _unitOfWork.EmbellishmentTypeRepository.Remove(embellishmentType);
            await _unitOfWork.SaveChanges();

            return Result<bool>.SuccessResult(true);

        }


        public async Task<Result<EmbellishmentTypeResponseDto>> GetEmbellishmentTypeById(int embellishmentTypeId)
        {
            EmbellishmentType? embellishmentType = await _unitOfWork.EmbellishmentTypeRepository
                .GetFirstOrDefault(x => x.EmbellishmentTypeId == embellishmentTypeId);

            if (embellishmentType is null)
            {
                return Result<EmbellishmentTypeResponseDto>.NotFoundResult(embellishmentTypeId);
            }
            return Result<EmbellishmentTypeResponseDto>.SuccessResult(_mapper.Map<EmbellishmentTypeResponseDto>(embellishmentType));
        }

        public async Task<Result<IEnumerable<EmbellishmentTypeResponseDto>>> GetEmbellishmentTypeList()
        {
            IEnumerable<EmbellishmentType> embellishmentTypes = await _unitOfWork.EmbellishmentTypeRepository.GetAll();

            if (!embellishmentTypes.Any())
            {
                return Result<IEnumerable<EmbellishmentTypeResponseDto>>.EmptyResult(nameof(EmbellishmentType));
            }

            return Result<IEnumerable<EmbellishmentTypeResponseDto>>.SuccessResult(_mapper.Map<IEnumerable<EmbellishmentTypeResponseDto>>(embellishmentTypes));

        }

        public async Task<Result<bool>> UpdateEmbellishmentType(int id, EmbellishmentTypeResponseDto embellishmentTypeResponseDto)
        {
            EmbellishmentType? embellishmentType = await _unitOfWork.EmbellishmentTypeRepository
               .GetFirstOrDefault(x => x.EmbellishmentTypeId == id);

            if (embellishmentType is null)
            {
                return Result<bool>.NotFoundResult(id);
            }
            _mapper.Map<EmbellishmentTypeResponseDto, EmbellishmentType>(embellishmentTypeResponseDto, embellishmentType);
            await _unitOfWork.SaveChanges();
            return Result<bool>.SuccessResult(true);
        }
    }
}