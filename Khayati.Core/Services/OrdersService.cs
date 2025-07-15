using AutoMapper;
using Entities;
using Entities.Enum;
using Khayati.Core.Common.Response;
using Khayati.Core.DTO;
using Khayati.Core.DTO.Orders;
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


        public async Task<Result<OrdersAddDto>> AddOrderWithDetails(OrdersAddDto orderDto)
        {

            var order = _mapper.Map<Order>(orderDto);
            if (order.OrderStatus == OrderStatus.Completed && order.Payments?.Any() == true)
            {
                order.CalculatePaymentStatus();
            }
            order.OrderDate = DateTime.UtcNow;
            await _unitOfWork.OrderRepository.Add(order);
            await _unitOfWork.SaveChanges(default);

            return Result<OrdersAddDto>.SuccessResult(orderDto);

        }



        private async Task<bool> IsPaidOrder(OrdersAddDto ordersAddDto)
        {

            var amoutPaid = ordersAddDto?.Payments?.Sum(x => x.Amount);

            if (amoutPaid >= ordersAddDto?.TotalCost)
            {

                return true;
            }
            return false;
        }


        private async Task<bool> IsPaidOrder1(Order order)
        {
            var existingOrder = await _unitOfWork.PaymentRepository
                .GetAll(x => x.OrderId == order.OrderId);
            if (existingOrder is null)
            {
                return false;

            }
            var amountPaid = existingOrder.Sum(x => x.Amount);

            if (amountPaid >= order.TotalCost)
            {
                return true;
            }
            return false;

        }

        // Calculates the total cost of an order
        public async Task<Result<IEnumerable<CustomerOrderResponseDto>>> GetOrdersByCustomerId(int customerId)
        {
            var customerOrderList = await _unitOfWork.OrderRepository.GetOrderListByCustomerId(customerId);
            if (customerOrderList.Any() == false)
            {
                return Result<IEnumerable<CustomerOrderResponseDto>>
                    .FailureResult(DeclareMessage.NotFound.Code,
                    $"Customer order with customer id {customerId} not found");
            }

            return Result<IEnumerable<CustomerOrderResponseDto>>.SuccessResult(customerOrderList!);
        }

        
        public async Task<Result<IEnumerable<OrderDto>>> GetOrders( )
        {
            var orders = await _unitOfWork.OrderRepository.GetAll();
            if (orders.Any() == false)
            {
                return Result<IEnumerable<OrderDto>>.EmptyResult();
            }

            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);

            return Result<IEnumerable<OrderDto>>.SuccessResult(ordersDto);

        }

        public async Task<Result<decimal?>>
            CalculateTotalCost(int orderId)
        {
            var order = await _unitOfWork.OrderRepository.GetOrderWithDetailsAsync(orderId);
            if (order == null) throw new Exception("Order not found");

            decimal? measurementCost = await CalculateMeasurementCost(order.CustomerId);

            // decimal? embellishmentCost = await CalculateEmbellishmentCost(order.OrderId);
            decimal? designCost = await CalculateDesignCost(order.OrderId);

            // Total cost calculation
            decimal? totalCost = measurementCost + designCost;

            return Result<decimal?>.SuccessResult(totalCost);
        }

        // Helper method to calculate measurement-based cost
        public async Task<decimal?>
            CalculateMeasurementCost(int customerId)
        {


            var measurement = await _unitOfWork.MeasurementRepository
                .GetLatestMeasurementByCustomerIdAsync(customerId);

            if (measurement == null) throw new Exception("Measurement not found");

            return default;
        }

        // Helper method to calculate embellishment cost
        public async Task<decimal?>
            CalculateEmbellishmentCost(int orderId)
        {
            var Embellishment = await _unitOfWork.EmbellishmentRepository
                .GetEmbellishmentListByOrderIdAsync(orderId);
            if (Embellishment == null) throw new Exception("No Embellishment found");

            return Embellishment.Sum(e => e.Cost ?? 0); // Assume Cost is nullable
        }

        // Helper method to calculate design cost
        public async Task<decimal?>
            CalculateDesignCost(int orderId)
        {

            return default;
            //var orderDesigns = await _unitOfWork.OrderDesignRepository
            //    .GetOrderDesignListByOrderIdAsync(orderId);
            //if (orderDesigns == null) throw new Exception("No designs found");

            //return orderDesigns.Sum(d => d.CostAtTimeOfOrder);
        }




        // Example method to create an order
        //public async Task CreateOrderAsync(OrderDto orderDto)
        //{
        //    var order = _mapper.Map<Order>(orderDto);

        //    // Calculate the total cost
        //    order.TotalCost = await CalculateTotalCost(order.OrderId);

        //    // Save order
        //    await _orderRepository.AddAsync(order);
        //    await _unitOfWork.SaveChangesAsync();
        //}


        //Task<decimal> IOrdersService.CalculateMeasurementCost(int customerId)
        //{
        //    throw new NotImplementedException();
        //}


    }
}
