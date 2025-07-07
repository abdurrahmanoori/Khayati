using AutoMapper;
using Khayati.Core.Common.Response;
using Khayati.Core.Domain.Entities;
using Khayati.Core.DTO.Fabric;
using Khayati.Core.ServiceContracts;
using RepositoryContracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.Core.Services
{
    public class FabricService : IFabricService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FabricService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<FabricResponseDto>> AddFabric(FabricAddDto dto)
        {
            var fabric = _mapper.Map<Fabric>(dto);
           await _unitOfWork.FabricRepository.Add(fabric);
           await _unitOfWork.SaveChanges();
            return Result<FabricResponseDto>.SuccessResult(_mapper.Map<FabricResponseDto>(fabric));
        }

        public async Task<Result<bool>> DeleteFabric(int id)
        {   var fabric = await _unitOfWork.FabricRepository.GetById(id);
            if (fabric == null) return Result<bool>.NotFoundResult(id);

            await _unitOfWork.FabricRepository.Remove(fabric);
            await _unitOfWork.SaveChanges();
            return Result<bool>.SuccessResult(true);
        }

        public async Task<Result<FabricResponseDto>> GetFabricById(int id)
        {
            var fabric = await _unitOfWork.FabricRepository
                .GetFirstOrDefault(x => x.FabricId == id);
            if (fabric == null) return Result<FabricResponseDto>.NotFoundResult(id);
            return Result<FabricResponseDto>.SuccessResult(_mapper.Map<FabricResponseDto>(fabric));

        }

        public async Task<Result<List<FabricResponseDto>>> GetFabricList()
        {
            var list =await _unitOfWork.FabricRepository.GetAll();
            if (!list.Any()) return Result<List<FabricResponseDto>>.EmptyResult(nameof(Fabric));
            return Result<List<FabricResponseDto>>.SuccessResult(_mapper.Map<List<FabricResponseDto>>(list));
        }

        public async Task<Result<bool>> UpdateFabric(int id, FabricAddDto dto)
        {
            var fabric =await _unitOfWork.FabricRepository.GetById(id);
            if (fabric == null) return Result<bool>.NotFoundResult(id);

            _mapper.Map(dto, fabric);
            await _unitOfWork.SaveChanges();
            return Result<bool>.SuccessResult(true);
        }
    }
}
