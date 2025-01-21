using Khayati.Core.Common.Response;
using Khayati.Core.DTO;

namespace Khayati.ServiceContracts
{
    public interface IPaymentService
    {
        public Task<Result<bool>> ProcessPaymentAsync(int orderId, decimal amountPaid);

        public Task AddPaymentForCustomer(int customerId, decimal amount);
        //public Task<OrdersAddDto> AddOrders(OrdersAddDto addOrdersDto);


    }
}
