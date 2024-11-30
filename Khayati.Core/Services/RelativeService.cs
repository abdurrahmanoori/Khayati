using AutoMapper;
using Khayati.Core.Common.Response;
using Khayati.Core.Domain.Entities;
using Khayati.Core.DTO.Relative;
using Khayati.ServiceContracts;
using RepositoryContracts.Base;

namespace Khayati.Service
{
    public class RelativeService : IRelativeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RelativeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<RelativeAddDto>>
            AddRelative(RelativeAddDto RelativeAddDto)
        {
            //Relative Relative = RelativeAddDto.ToRelative();
            Relative relative = _mapper.Map<Relative>(RelativeAddDto);

            await _unitOfWork.RelativeRepository.Add(relative);
            await _unitOfWork.SaveChanges(CancellationToken.None);
            return Result<RelativeAddDto>.SuccessResult(RelativeAddDto);

        }

        public async Task<Result<RelativeResponseDto>>
            DeleteRelative(int relativeId)
        {
            Relative? relative = await _unitOfWork.RelativeRepository.GetById(relativeId);
            if (relative is null)
            {
                return Result<RelativeResponseDto>
                    .FailureResult(DeclareMessage.NotFound.Code, $"relative with ID {relativeId} not found.");
            }
            await _unitOfWork.RelativeRepository.Remove(relative);
            await _unitOfWork.SaveChanges(default);
            var dto = _mapper.Map<RelativeResponseDto>(relative);
            return Result<RelativeResponseDto>.SuccessResult(dto);

        }

      
        public async Task<Result<RelativeResponseDto>>
            GetRelativeById(int relativeId)
        {
            Relative relative = await _unitOfWork.RelativeRepository
                .GetFirstOrDefault(x => x.RelativeId == relativeId);
            if (relative is null)
            {
                return Result<RelativeResponseDto>
                   .FailureResult(DeclareMessage.NotFound.Code, $"Relative with ID {relativeId} not found.");
            }

            RelativeResponseDto relativeResponseDto =
                _mapper.Map<RelativeResponseDto>(relative);

            return Result<RelativeResponseDto>.SuccessResult(relativeResponseDto);

        }

        public Task<Result<RelativeResponseDto>> GetRelativeById(int? RelativeId)
        {
            throw new NotImplementedException();
        }




        //public async Task<Result<RelativeDetailDto>>
        //    GetRelativeDetails(int relativeId)
        //{
        //    var query = (
        //        from e in await _unitOfWork.RelativeRepository.GetAll()
        //        join et in await _unitOfWork.RelativeTypeRepository.GetAll()
        //        on e.RelativeTypeId equals et.RelativeTypeId
        //        where e.RelativeId == RelativeId
        //        select new RelativeDetailDto
        //        {
        //            RelativeId = e.RelativeId,
        //            Name = e.Name,
        //            RelativeTypeName = et.Name,
        //            RelativeTypeId = et.RelativeTypeId,
        //        }).FirstOrDefault();
        //    if (query is null)
        //    {
        //        return Result<RelativeDetailDto>
        //           .FailureResult(DeclareMessage.NotFound.Code, $"Relative with ID {RelativeId} not found.");
        //    }

        //    return Result<RelativeDetailDto>.SuccessResult(query);
        //}

        public async Task<Result<IEnumerable<RelativeDto>>>
            GetRelativeList( )
        {
            IEnumerable<Relative> relatives =
              await _unitOfWork.RelativeRepository.GetAll(includeProperties: "Customer");
              

            if (relatives.Any() == false)
            {

                return Result<IEnumerable<RelativeDto>>
                    .FailureResult(DeclareMessage.EmptyList.Code, DeclareMessage.EmptyList.Description);

            }
          var  relativesDto = _mapper.Map<IEnumerable<RelativeDto>>(relatives);
            return Result<IEnumerable<RelativeDto>>.SuccessResult(relativesDto);

        }

        //public async Task<Result<RelativeUpdateDto>>
        //    Update(int RelativeId, RelativeUpdateDto updateDto)
        //{
        //    var Relative = await _unitOfWork
        //        .RelativeRepository
        //        .GetFirstOrDefault(x => x.RelativeId == RelativeId);

        //    if (Relative == null)
        //    {
        //        return Result<RelativeUpdateDto>
        //            .FailureResult("NotFound", $"The Relative with the provided {RelativeId} ID was not found.");
        //    }

        //    _mapper.Map(updateDto, Relative);
        //    Relative.RelativeId = RelativeId;
        //    await _unitOfWork.SaveChanges(CancellationToken.None);

        //    return Result<RelativeUpdateDto>.SuccessResult(updateDto);
        //}
        //public Task<Result<string>> Update(RelativeUpdateDto updateDto)
        //{
        //    return Result<bool>.FailureResult()
        //    return Task.FromResult(Result<string>.SuccessResult("not found"));
        //}
    }
}
