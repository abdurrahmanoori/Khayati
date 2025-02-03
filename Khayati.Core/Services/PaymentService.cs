using AutoMapper;
using Entities.Enum;
using Entities;
using Khayati.ServiceContracts;
using RepositoryContracts.Base;
using Khayati.Core.Common.Response;

namespace Khayati.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<bool>> ProcessPaymentAsync(int orderId, decimal amountPaid)
        {
            // Validate and fetch the order
            var order = await FetchValidateOrder(orderId);
            if (order == null)
                return Result<bool>.FailureResult(DeclareMessage.NotFound.Code, "Order not found or already paid.");

            if (order.TotalCost == 0)
                return Result<bool>.FailureResult(DeclareMessage.InvalidOperation.Code, "Operation cannot be done because Total cost is zero.");

            // Calculate outstanding amount
            var outstandingAmount = await CalculateOutstandingAmount(orderId, order.TotalCost);

            // Create and configure the payment
            var payment = CreatePayment(orderId, amountPaid);
            UpdateOrderStatus(order, amountPaid, outstandingAmount);

            // Persist changes
            await _unitOfWork.PaymentRepository.Add(payment);
            await _unitOfWork.SaveChanges(CancellationToken.None);

            return Result<bool>.SuccessResult(true);
        }



        public async Task AddPaymentForCustomer(int customerId, decimal amount)
        {
            var customer = await FetchCustomer(customerId);
            var order = await GetOrCreateCustomerOrder(customerId);

            // Create and save the payment
            var payment = CreatePayment(order.OrderId, amount);
            await SavePayment(payment);

            // Save changes for both order and payment
            await _unitOfWork.SaveChanges(default);
        }




        private async Task<Customer> FetchCustomer(int customerId)
        {
            var customer = await _unitOfWork.CustomerRepository
                .GetFirstOrDefault(x => x.CustomerId == customerId);

            if (customer == null)
                throw new Exception("Customer not found");

            return customer;
        }

        private async Task<Order> GetOrCreateCustomerOrder(int customerId)
        {
            var orders = await _unitOfWork.OrderRepository
                .GetAll(x => x.CustomerId == customerId && !x.IsPaid && x.OrderStatus != OrderStatus.Completed);

            var order = orders.OrderByDescending(x => x.OrderDate).FirstOrDefault();

            // If no order exists, create a new one
            if (order == null)
            {
                order = new Order
                {
                    CustomerId = customerId,
                    OrderDate = DateTime.Now,
                    ExpectedCompletionDate = DateTime.Now.AddDays(7), // Example completion time
                    TotalCost = 0, // Since we don't know the cost yet
                    IsPaid = false,
                    OrderStatus = OrderStatus.Pending,
                    PaymentStatus = PaymentStatus.PartialPayment
                };
                await _unitOfWork.OrderRepository.Add(order);

            }

            return order;
        }

        private async Task<Order?> FetchValidateOrder(int orderId)
        {
            return await _unitOfWork.OrderRepository.GetFirstOrDefault(
                x => x.OrderId == orderId && !x.IsPaid && x.OrderStatus != OrderStatus.Completed);
        }

        private async Task<decimal> CalculateOutstandingAmount(int orderId, decimal? totalCost)
        {
            var totalPayments = await _unitOfWork.PaymentRepository.GetTotalPaymentsByOrderIdAsync(orderId);
            return (totalCost ?? 0) - (decimal)totalPayments;
        }

        private Payment CreatePayment(int orderId, decimal amountPaid)
        {
            return new Payment
            {
                Amount = amountPaid,
                PaymentDate = DateTime.UtcNow,
                OrderId = orderId,
            };
        }

        private void UpdateOrderStatus(Order order, decimal amountPaid, decimal outstandingAmount)
        {
            if (amountPaid >= outstandingAmount)
            {
                order.PaymentStatus = PaymentStatus.Completed;
                order.IsPaid = true;
                order.OrderStatus = OrderStatus.Completed;
            }
            else
            {
                order.PaymentStatus = PaymentStatus.PartialPayment;
                order.IsPaid = false;
                order.OrderStatus = OrderStatus.Progress;
            }
        }



        private async Task SavePayment(Payment payment)
        {
            await _unitOfWork.PaymentRepository.Add(payment);
            await _unitOfWork.SaveChanges(default);
        }



    }
}
