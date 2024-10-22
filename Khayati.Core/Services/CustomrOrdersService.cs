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

        public async Task<BaseCommandResponse<CustomerAddDto>> CreateCustomerOrder(CustomerAddDto customerDto, MeasurementAddDto measurementDto, OrdersAddDto orderDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _unitOfWork.CustomerRepository.Add(customer);

            var measurment = _mapper.Map<Measurement>(measurementDto);
            measurment.Customer = customer;
            await _unitOfWork.MeasurementRepository.Add(measurment);

            var order = _mapper.Map<Order>(orderDto);
            order.OrderDate = DateTime.UtcNow;
            order.OrderStatus = OrderStatus.Pending.ToString();
            order.Customer = customer;
            order.IsPaid = false;
            


           await _unitOfWork.SaveChanges(default);
            return null;

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
