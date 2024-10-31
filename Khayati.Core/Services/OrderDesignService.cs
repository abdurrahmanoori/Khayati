using AutoMapper;
using Entities;
using Khayati.ServiceContracts;
using RepositoryContracts.Base;
using Khayati.Core.DTO.OrderDesign;

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

        public async Task<OrderDesignAddDto> AddOrderDesign(OrderDesignAddDto OrderDesignAddDto)
        {
            if (OrderDesignAddDto == null)
            {
                return null;
            }

            var OrderDesign = _mapper.Map<OrderDesign>(OrderDesignAddDto);



            await _unitOfWork.OrderDesignRepository.Add(OrderDesign);
            await _unitOfWork.SaveChanges(CancellationToken.None);
            return OrderDesignAddDto;

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