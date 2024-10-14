using Entities;
using Khayati.Core.DTO;
using Khayati.ServiceContracts;
using RepositoryContracts.Base;

namespace Khayati.Service
{
    public class OrdersService : IOrdersService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrdersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OrdersAddDto> AddOrders(OrdersAddDto OrdersAddDto)
        {
            if (OrdersAddDto == null)
            {
                return null;
            }
            Order Orders = OrdersAddDto.ToOrders();
            await _unitOfWork.OrderRepository.Add(Orders);
            await _unitOfWork.SaveChanges(CancellationToken.None);
            return OrdersAddDto;

        }

        public async Task<OrdersResponseDto> DeleteOrders(int? OrdersId)
        {
            if (!OrdersId.HasValue)
            {
                return null;
            }
            Order Orders = await _unitOfWork.OrderRepository.GetById((int)OrdersId);
            if (Orders == null)
            {
                return null;
            }
            await _unitOfWork.OrderRepository.Remove(Orders);
            await _unitOfWork.SaveChanges(default);

            return Orders.ToOrdersResponseDto();

        }


        public async Task<OrdersResponseDto> GetOrdersById(int? OrdersId)
        {
            if (OrdersId == null || OrdersId == 0)
            {
                return null;
            }
            Order Orders = await _unitOfWork.OrderRepository
                .GetFirstOrDefault(x => x.OrderId == OrdersId);

            OrdersResponseDto OrdersResponseDto = Orders.ToOrdersResponseDto();
            return OrdersResponseDto;

        }

        public async Task<IEnumerable<OrdersResponseDto>> GetOrdersList()
        {
            IEnumerable<Order> Orderss = await _unitOfWork.OrderRepository.GetAll();
            if (Orderss is null)
            {
                return null;
            }

            IEnumerable<OrdersResponseDto> OrdersResponseDtos = Orderss
                .Select(temp => temp.ToOrdersResponseDto());

            return OrdersResponseDtos;

        }

    }
}
