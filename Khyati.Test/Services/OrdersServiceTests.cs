using AutoMapper;
using Entities;
using Entities.Enum;
using FluentAssertions;
using Khayati.Core.DTO;
using Khayati.Core.DTO.Payment;
using Khayati.Service;
using Moq;
using RepositoryContracts.Base;

namespace Khayati.Tests.Services
{
    public class OrdersServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly OrdersService _ordersService;

        public OrdersServiceTests( )
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _ordersService = new OrdersService(_unitOfWorkMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task AddOrderWithDetails_Should_Add_Order_And_Return_Success( )
        {
            // Arrange
            var orderDto = new OrdersAddDto
            {
                CustomerId = 1,
                OrderStatus = OrderStatus.Pending,
                TotalCost = 100.0m,
                Payments = new List<PaymentDto>
                {
                    new PaymentDto { Amount = 50m, PaymentDate = DateTime.UtcNow }
                }
            };

            var orderEntity = new Order
            {
                CustomerId = 1,
                OrderStatus = OrderStatus.Pending,
                TotalCost = 100.0m,
                Payments = new List<Payment>
                {
                    new Payment { Amount = 50m, PaymentDate = DateTime.UtcNow }
                }
            };

            _mapperMock.Setup(m => m.Map<Order>(It.IsAny<OrdersAddDto>())).Returns(orderEntity);
            _unitOfWorkMock.Setup(u => u.OrderRepository.Add(It.IsAny<Order>())).Returns(Task.CompletedTask);
            _unitOfWorkMock.Setup(u => u.SaveChanges(default)).Returns(Task.CompletedTask);

            // Act
            var result = await _ordersService.AddOrderWithDetails(orderDto);

            // Assert
            result.Success.Should().BeTrue();
            result.Response.Should().BeEquivalentTo(orderDto);
            _unitOfWorkMock.Verify(u => u.OrderRepository.Add(It.IsAny<Order>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.SaveChanges(default), Times.Once);
        }

        [Fact]
        public async Task AddOrderWithDetails_Should_Calculate_PaymentStatus_When_Order_Is_Completed( )
        {
            // Arrange
            var orderDto = new OrdersAddDto
            {
                CustomerId = 2,
                OrderStatus = OrderStatus.Completed,
                TotalCost = 200.0m,
                Payments = new List<PaymentDto>
                {
                    new PaymentDto { Amount = 200m, PaymentDate = DateTime.UtcNow }
                }
            };

            var orderEntity = new Order
            {
                CustomerId = 2,
                OrderStatus = OrderStatus.Completed,
                TotalCost = 200.0m,
                Payments = new List<Payment>
                {
                    new Payment { Amount = 200m, PaymentDate = DateTime.UtcNow }
                }
            };

            _mapperMock.Setup(m => m.Map<Order>(It.IsAny<OrdersAddDto>())).Returns(orderEntity);
            _unitOfWorkMock.Setup(u => u.OrderRepository.Add(It.IsAny<Order>())).Returns(Task.CompletedTask);
            _unitOfWorkMock.Setup(u => u.SaveChanges(default)).Returns(Task.CompletedTask);

            // Act
            var result = await _ordersService.AddOrderWithDetails(orderDto);

            // Assert
            result.Success.Should().BeTrue();
            orderEntity.PaymentStatus.Should().Be(PaymentStatus.Paid);
            orderEntity.IsPaid.Should().BeTrue();
        }
    }
}
