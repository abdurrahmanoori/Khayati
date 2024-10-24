using AutoMapper;
using Entities;
using Entities.Enum;
using Khayati.Core.Common.Response;
using Khayati.Core.DTO;
using Khayati.ServiceContracts;
using RepositoryContracts.Base;

namespace Khayati.Service
{
    public class OrdersService : IOrdersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrdersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<BaseCommandResponse<CustomerAddDto>> AddOrder(CustomerAddDto customerDto, MeasurementAddDto measurementDto, OrdersAddDto orderDto)
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

        public Task<decimal> CalculateEmbellishmentCost(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> CalculateMeasurementCost(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> CalculateTotalCost(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
