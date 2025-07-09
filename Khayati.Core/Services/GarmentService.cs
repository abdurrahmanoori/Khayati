using AutoMapper;
using Entities;
using Khayati.Core.Common.Response;
using Khayati.Core.Domain.Entities;
using Khayati.Core.DTO;
using Khayati.Core.DTO.Garments;
using Khayati.ServiceContracts;
using RepositoryContracts.Base;

namespace Khayati.Service
{
    public class GarmentService : IGarmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GarmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<GarmentDto>> AddGarment(GarmentAddDto dto)
        {
            var entity = _mapper.Map<Garment>(dto);
            await _unitOfWork.GarmentRepository.Add(entity);
            await _unitOfWork.SaveChanges();
            return Result<GarmentDto>.SuccessResult(_mapper.Map<GarmentDto>(entity));
        }

        public async Task<Result<bool>> DeleteGarment(int id)
        {
            var entity = await _unitOfWork.GarmentRepository.GetById(id);
            if (entity == null) return Result<bool>.NotFoundResult(id);

            await _unitOfWork.GarmentRepository.Remove(entity);
            await _unitOfWork.SaveChanges();
            return Result<bool>.SuccessResult(true);
        }

        public async Task<Result<GarmentDto>> GetGarmentById(int id)
        {
            var entity = await _unitOfWork.GarmentRepository
                .GetFirstOrDefault(x => x.GarmentId== id);
            if (entity == null) return Result<GarmentDto>.NotFoundResult(id);

            return Result<GarmentDto>.SuccessResult(_mapper.Map<GarmentDto>(entity));
        }


        public async Task<Result<List<GarmentDto>>> GetGarmentList()
        {
            var list = await _unitOfWork.GarmentRepository.GetAll(includeProperties: "GarmentFields");

            if (!list.Any()) return Result<List<GarmentDto>>.EmptyResult(nameof(Garment));
            return Result<List<GarmentDto>>.SuccessResult(_mapper.Map<List<GarmentDto>>(list));
        }

        public async Task<Result<bool>> UpdateGarment(int id, GarmentDto dto)
        {
            var entity = await _unitOfWork.GarmentRepository.GetById(id);
            if (entity == null) return Result<bool>.NotFoundResult(id);

            _mapper.Map(dto, entity);
            await _unitOfWork.SaveChanges();
            return Result<bool>.SuccessResult(true);
        }
    }
}