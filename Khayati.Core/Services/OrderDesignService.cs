using AutoMapper;
using Entities;
using Khayati.Core.Common.Response;
using Khayati.Core.DTO.OrderDesign;
using Khayati.ServiceContracts;
using RepositoryContracts.Base;

namespace Khayati.Service
{
    public class OrderDesignService : IOrderDesignService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderDesignService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<OrderDesignAddDto>> AddOrderDesign(OrderDesignAddDto orderDesignAddDto)
        {
            if (orderDesignAddDto == null)
            {
                return Result<OrderDesignAddDto>.FailureResult(DeclareMessage.BadRequest.Code, DeclareMessage.BadRequest.Description);
            }

            var orderDesign = _mapper.Map<OrderDesign>(orderDesignAddDto);

            if (orderDesignAddDto.EmbellishmentId.HasValue)
            {

                var embellishment = await _unitOfWork.EmbellishmentRepository
                    .GetFirstOrDefault(e => e.EmbellishmentId == orderDesignAddDto.EmbellishmentId.Value);

                if (embellishment == null) Result<OrderDesignAddDto>.FailureResult(DeclareMessage.NotFound.Code, DeclareMessage.NotFound.Description);

                // Set the CostAtTimeOfOrder in OrderDesign based on the Embellishment's Cost

                orderDesign.CostAtTimeOfOrder = embellishment?.Cost;
            }

            // Add the OrderDesign entity to the repository
            await _unitOfWork.OrderDesignRepository.Add(orderDesign);
            await _unitOfWork.SaveChanges(CancellationToken.None);

            return Result<OrderDesignAddDto>.SuccessResult(orderDesignAddDto);
        }

        //public async Task<OrderDesignResponseDto> DeleteOrderDesign(int? OrderDesignId)
        //{
        //    if (!OrderDesignId.HasValue)
        //    {
        //        return null;
        //    }
        //    OrderDesign OrderDesign = await _unitOfWork.OrderDesignRepository.GetById((int)OrderDesignId);
        //    if (OrderDesign == null)
        //    {
        //        return null;
        //    }
        //    await _unitOfWork.OrderDesignRepository.Remove(OrderDesign);
        //    await _unitOfWork.SaveChanges(default);

        //    return OrderDesign.ToOrderDesignResponseDto();

        //}


        //public async Task<OrderDesignResponseDto> GetOrderDesignById(int? OrderDesignId)
        //{
        //    if (OrderDesignId == null || OrderDesignId == 0)
        //    {
        //        return null;
        //    }
        //    OrderDesign OrderDesign = await _unitOfWork.OrderDesignRepository
        //        .GetFirstOrDefault(x => x.OrderDesignId == OrderDesignId);

        //    OrderDesignResponseDto OrderDesignResponseDto = OrderDesign.ToOrderDesignResponseDto();
        //    return OrderDesignResponseDto;

        //}

        //public async Task<IEnumerable<OrderDesignResponseDto>> GetOrderDesignList()
        //{
        //    IEnumerable<OrderDesign> OrderDesigns = await _unitOfWork.OrderDesignRepository.GetAll();
        //    if (OrderDesigns is null)
        //    {
        //        return null;
        //    }

        //    var OrderDesignResponseDtos = _mapper.Map<IEnumerable<OrderDesignResponseDto>>(OrderDesigns);

        //    //IEnumerable<OrderDesignResponseDto> OrderDesignResponseDtos = OrderDesigns
        //    //    .Select(temp => temp.ToOrderDesignResponseDto());

        //    return OrderDesignResponseDtos;

        //}

    }
}