﻿using AutoMapper;
using Entities;
using Entities.Enum;
using Khayati.Core.Common.Response;
using Khayati.Core.DTO;
using Khayati.Core.DTO.Measurements;
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


        public async Task<Result<CustomerAddDto>> AddOrderWithDetails(
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
            order.OrderStatus = OrderStatus.Pending;
            order.Customer = customer;
            order.IsPaid = false;

            await _unitOfWork.OrderRepository.Add(order);

            await _unitOfWork.SaveChanges(default);
            return Result<CustomerAddDto>.SuccessResult(customerDto);

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

        public async Task<decimal?>
            CalculateTotalCost(int orderId)
        {
            var order = await _unitOfWork.OrderRepository.GetOrderWithDetailsAsync(orderId);
            if (order == null) throw new Exception("Order not found");

            decimal? measurementCost = await CalculateMeasurementCost(order.CustomerId);

            // decimal? embellishmentCost = await CalculateEmbellishmentCost(order.OrderId);
            decimal? designCost = await CalculateDesignCost(order.OrderId);

            // Total cost calculation
            decimal? totalCost = measurementCost + designCost;

            return totalCost;
        }

        // Helper method to calculate measurement-based cost
        public async Task<decimal?>
            CalculateMeasurementCost(int customerId)
        {


            var measurement = await _unitOfWork.MeasurementRepository
                .GetLatestMeasurementByCustomerIdAsync(customerId);

            if (measurement == null) throw new Exception("Measurement not found");

            return measurement.Cost ?? 0;
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
            var orderDesigns = await _unitOfWork.OrderDesignRepository
                .GetOrderDesignListByOrderIdAsync(orderId);
            if (orderDesigns == null) throw new Exception("No designs found");

            return orderDesigns.Sum(d => d.CostAtTimeOfOrder);
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
