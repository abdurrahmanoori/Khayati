
using Khayati.Core.Common.Response;
using Khayati.Core.DTO;
using Khayati.Core.DTO.Orders;
namespace Khayati.ServiceContracts
{
    public interface IOrdersService
    {

        Task<Result<OrderDto>> AddOrderWithDetails(OrderDto order);

        public Task<Result< decimal?>> CalculateTotalCost(int orderId);

        public Task<decimal?> CalculateMeasurementCost(int customerId);

        public Task<decimal?> CalculateEmbellishmentCost(int orderId);

        public Task<decimal?> CalculateDesignCost(int orderId);
        public Task<Result<IEnumerable<OrdersResponseDto>>> GetAllOrders();
        public Task<Result<bool>> DeleteOrder(int Id);
        Task<Result<IEnumerable<CustomerOrderResponseDto>>> GetOrdersByCustomerId(int customerId);
        Task<Result<IEnumerable<OrderDto>>> GetOrders( );
        //public Task<decimal> CalculateTotalCost (Order order);

        //public Task<OrdersAddDto> AddOrders(OrdersAddDto addOrdersDto);
        //public Task<OrdersResponseDto> GetOrdersById(int? OrdersId);

        //public Task<IEnumerable<OrdersResponseDto>> GetOrdersList();

        //public Task<OrdersResponseDto> DeleteOrders(int? OrdersId);
        // public Task<OrdersResponseDto> UpdateOrders(int? OrdersId);

    }
}
