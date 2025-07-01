using AutoMapper;
using Entities;
using Khayati.Core.Common.Response;
using Khayati.Core.DTO;
using Khayati.Core.DTO.Embellishment;
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

        public async Task<Result<EmbellishmentAddDto>> AddEmbellishment(EmbellishmentAddDto dto)
        {
            var entity = _mapper.Map<Embellishment>(dto);
            await _unitOfWork.EmbellishmentRepository.Add(entity);
            await _unitOfWork.SaveChanges();
            return Result<EmbellishmentAddDto>.SuccessResult(_mapper.Map<EmbellishmentAddDto>(entity));
        }

        public async Task<Result<bool>> DeleteEmbellishment(int id)
        {
            var entity = await _unitOfWork.EmbellishmentRepository.GetById(id);
            if (entity == null) return Result<bool>.NotFoundResult(id);

            await _unitOfWork.EmbellishmentRepository.Remove(entity);
            await _unitOfWork.SaveChanges();
            return Result<bool>.SuccessResult(true);
        }

        public async Task<Result<EmbellishmentResponseDto>> GetEmbellishmentById(int id)
        {
            var entity = await _unitOfWork.EmbellishmentRepository.GetFirstOrDefault(x => x.EmbellishmentId == id);
            if (entity == null) return Result<EmbellishmentResponseDto>.NotFoundResult(id);

            return Result<EmbellishmentResponseDto>.SuccessResult(_mapper.Map<EmbellishmentResponseDto>(entity));
        }

        public async Task<Result<IEnumerable<EmellishmentResponseDetailsDto>>> GetEmbellishmentList()
        {
            var entities = await _unitOfWork.EmbellishmentRepository.GetAll(includeProperties: "EmbellishmentType");
            if (!entities.Any()) return Result<IEnumerable<EmellishmentResponseDetailsDto>>.EmptyResult(nameof(Embellishment));

            return Result<IEnumerable<EmellishmentResponseDetailsDto>>.SuccessResult(_mapper.Map<IEnumerable<EmellishmentResponseDetailsDto>>(entities));
        }

        public async Task<Result<bool>> UpdateEmbellishment(int id, EmbellishmentResponseDto dto)
        {
            var entity = await _unitOfWork.EmbellishmentRepository.GetById(id);
            if (entity == null) return Result<bool>.NotFoundResult(id);

            _mapper.Map(dto, entity);
            await _unitOfWork.SaveChanges();
            return Result<bool>.SuccessResult(true);
        }
    }

}
