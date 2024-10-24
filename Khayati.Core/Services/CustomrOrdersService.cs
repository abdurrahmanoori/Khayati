using AutoMapper;
using Entities;
using Entities.Enum;
using Khayati.Core.Common.Response;
using Khayati.Core.DTO;
using Khayati.ServiceContracts;
using RepositoryContracts.Base;
using System.Reflection.Metadata.Ecma335;

namespace Khayati.Service
{
    public class CustomrOrdersService : ICustomrOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomrOrdersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

      
        //public async Task<OrdersAddDto> AddOrders(OrdersAddDto OrdersAddDto)
        //{
        //    if (OrdersAddDto == null)
        //    {
        //        return null;
        //    }
        //    Order Orders = OrdersAddDto.ToOrders();
        //    await _unitOfWork.OrderRepository.Add(Orders);
        //    await _unitOfWork.SaveChanges(CancellationToken.None);
        //    return OrdersAddDto;

        //}



    }
}
