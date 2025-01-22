using AutoMapper;
using Entities.Enum;
using Entities;
using Khayati.ServiceContracts;
using RepositoryContracts.Base;
using Khayati.Core.DTO.Payment;
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
            // Fetch the order
            var order = await _unitOfWork.OrderRepository
                .GetFirstOrDefault(x => x.OrderId == orderId);

            if (order == null) return Result<bool>.FailureResult(DeclareMessage.NotFound.Code, "Order not found.");

            // Calculate outstanding(Remaining money) amount by summing all payments directly from the Payment repository
            var totalPayments = await _unitOfWork.PaymentRepository
                .GetTotalPaymentsByOrderIdAsync(orderId);

            var outstandingAmount = order.TotalCost - totalPayments;

            // Create a new payment entry
            var paymentDto = new PaymentDto
            {
                Amount = amountPaid,
                PaymentDate = DateTime.UtcNow,
                OrderId = orderId,
                PaymentStatus = amountPaid >= outstandingAmount
                    ? PaymentStatus.Completed
                    : PaymentStatus.PartialPayment
            };

            // Update the order's IsPaid and OrderStatus without using navigation properties
            if (amountPaid >= outstandingAmount)
            {
                order.IsPaid = true;
                order.OrderStatus = OrderStatus.Completed;
            }
            else
            {
                order.IsPaid = false;
                order.OrderStatus = OrderStatus.Progress;
            }

            var payment = _mapper.Map<Payment>(paymentDto);

            // Save the payment and update the order
            await _unitOfWork.PaymentRepository.Add(payment);
            await _unitOfWork.SaveChanges(CancellationToken.None);
            //await _orderRepository.UpdateAsync(order);

            return Result<bool>.SuccessResult(true);

        }


        public async Task AddPaymentForCustomer(int customerId, decimal amount)
        {
            var customer = await _unitOfWork.CustomerRepository
                .GetFirstOrDefault(x => x.CustomerId == customerId,includeProperties: "Measurements");

            if (customer == null)
                throw new Exception("Customer not found");

            // Check if the customer has any existing orders
            var orders = await _unitOfWork.OrderRepository
                .GetAll(x => x.CustomerId == customerId && !x.IsPaid);

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

            // Now create the payment
            var payment = new Payment
            {
                OrderId = order.OrderId,
                Order = order,
                Amount = amount,
                PaymentDate = DateTime.Now,
                //PaymentStatus = PaymentStatus.PartialPayment // Assume partial by default
            };

            await _unitOfWork.PaymentRepository.Add(payment);
            await _unitOfWork.SaveChanges(default);
            //_context.Payments.Add(payment);

            //// Update Order Status
            //order.IsPaid = (order.AmountPaid + amount) >= order.TotalCost;
            //await _context.SaveChangesAsync();
        }
    }
}
