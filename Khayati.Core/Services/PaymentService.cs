using AutoMapper;
using Entities.Enum;
using Entities;
using Khayati.ServiceContracts;
using RepositoryContracts;
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
                order.OrderStatus = OrderStatus.Completed.ToString();
            }
            else
            {
                order.IsPaid = false;
                order.OrderStatus = OrderStatus.Progress.ToString();
            }

            var payment = _mapper.Map<Payment>(paymentDto);

            // Save the payment and update the order
            await _unitOfWork.PaymentRepository.Add(payment);
            await _unitOfWork.SaveChanges(CancellationToken.None);
            //await _orderRepository.UpdateAsync(order);

            return Result<bool>.SuccessResult(true);

        }

    }
}
