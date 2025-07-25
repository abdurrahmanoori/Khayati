﻿using AutoMapper;
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


        public async Task<Result<OrderDto>> AddOrderWithDetails(OrderDto orderDto)
        {
            var isDuplicate = await _unitOfWork.OrderRepository
                .AnyAsync(x => x.CustomerId == orderDto.CustomerId && x.ExpectedCompletionDate == orderDto.ExpectedCompletionDate);
            if (isDuplicate)
            {
                return Result<OrderDto>.FailureResult(DeclareMessage.Duplicate.Code!, DeclareMessage.Duplicate.Description!);
            }


            var order = _mapper.Map<Order>(orderDto);
            if (order.OrderStatus == OrderStatus.Completed && order.Payments?.Any() == true)
            {
                order.CalculatePaymentStatus();
            }
            order.OrderDate = DateTime.UtcNow;
            await _unitOfWork.OrderRepository.Add(order);
            await _unitOfWork.SaveChanges(default);

            return Result<OrderDto>.SuccessResult(_mapper.Map<OrderDto>(order));

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
            var orders = await _unitOfWork.OrderRepository.GetAll(includeProperties: "Customer,Payments,OrderGarments");
            if (orders.Any() == false)
            {
                return Result<IEnumerable<OrderDto>>.EmptyResult();
            }

            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);

            return Result<IEnumerable<OrderDto>>.SuccessResult(ordersDto);

        }

        public async Task<Result<decimal?>> CalculateTotalCost(int orderId)
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

        public Task<Result<IEnumerable<OrdersResponseDto>>> GetAllOrders( )
        {
            throw new NotImplementedException();
        }

        public async Task<Result<bool>> DeleteOrder(int Id)
        {
            var order = await _unitOfWork.OrderRepository.GetFirstOrDefault(x=> x.OrderId == Id);
            if (order == null) return Result<bool>.NotFoundResult(Id);
            await _unitOfWork.OrderRepository.Remove(order);
            await _unitOfWork.SaveChanges(default);
            return Result<bool>.SuccessResult(true);
        }




    }
}
