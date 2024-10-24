using AutoMapper;
using Entities;
using Entities.Enum;
using Khayati.Core.Common.Response;
using Khayati.Core.DTO;
using Khayati.ServiceContracts;
using RepositoryContracts;
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


        public async Task<BaseCommandResponse<CustomerAddDto>> AddOrder(
            CustomerAddDto customerDto,
            MeasurementAddDto measurementDto,
            OrdersAddDto orderDto)
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

        // Calculates the total cost of an order
        public async Task<decimal> CalculateTotalCost(int orderId)
        {
            var order = await _unitOfWork.OrderRepository.GetOrderWithDetailsAsync(orderId);
            if (order == null) throw new Exception("Order not found");

            decimal measurementCost = await CalculateMeasurementCost(order.CustomerId);
            decimal embellishmentCost = await CalculateEmbellishmentCost(order.OrderId);
            decimal designCost = await CalculateDesignCost(order.OrderId);

            // Total cost calculation
            decimal totalCost = measurementCost + embellishmentCost + designCost;

            return totalCost;
        }

        // Helper method to calculate measurement-based cost
        private async Task<decimal> CalculateMeasurementCost(int customerId)
        {
           

            var measurement = await _unitOfWork.MeasurementRepository.GetLatestMeasurementByCustomerIdAsync(customerId);
            if (measurement == null) throw new Exception("Measurement not found");

            // Business rule for measurement-based pricing (e.g., based on custom tailoring costs)
            return measurement. // Example calculation
        }

        // Helper method to calculate embellishment cost
        private async Task<decimal> CalculateEmbellishmentCost(int orderId)
        {
            var embellishments = await _embellishmentRepository.GetEmbellishmentsByOrderIdAsync(orderId);
            if (embellishments == null) throw new Exception("No embellishments found");

            return embellishments.Sum(e => e.Cost ?? 0); // Assume Cost is nullable
        }

        // Helper method to calculate design cost
        private async Task<decimal> CalculateDesignCost(int orderId)
        {
            var orderDesigns = await _orderDesignRepository.GetOrderDesignsByOrderIdAsync(orderId);
            if (orderDesigns == null) throw new Exception("No designs found");

            return orderDesigns.Sum(d => d.Price); // Assuming Price is defined on OrderDesign
        }

        // Example method to create an order
        public async Task CreateOrderAsync(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);

            // Calculate the total cost
            order.TotalCost = await CalculateTotalCost(order.OrderId);

            // Save order
            await _orderRepository.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();
        }


    }
}
