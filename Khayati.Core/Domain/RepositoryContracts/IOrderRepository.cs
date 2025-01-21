using RepositoryContracts.Base;
using Entities;
using Khayati.Core.DTO.Orders;

namespace RepositoryContracts
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<CustomerOrderResponseDto?>>
            GetOrderListByCustomerId(int customerId);

        public  Task<Order?>
            GetOrderWithDetailsAsync(int orderId);
    }
}
