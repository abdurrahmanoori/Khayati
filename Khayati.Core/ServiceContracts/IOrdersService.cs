using Entities;
using Khayati.Core.Common.Response;
using Khayati.Core.DTO;
using Khayati.Core.DTO.Measurements;
using Khayati.Core.DTO.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.ServiceContracts
{
    public interface IOrdersService
    {

        Task<Result<OrdersAddDto>> AddOrderWithDetails(OrdersAddDto order);

        public Task<Result< decimal?>> CalculateTotalCost(int orderId);

        public Task<decimal?> CalculateMeasurementCost(int customerId);

        public Task<decimal?> CalculateEmbellishmentCost(int orderId);

        public Task<decimal?> CalculateDesignCost(int orderId);
        public Task<Result<IEnumerable<OrdersResponseDto>>> GetAllOrders();
        public Task<Result<bool>> DeleteOrder(int Id);
        Task<Result<IEnumerable<CustomerOrderResponseDto>>> GetOrdersByCustomerId(int customerId);
        public Task<Result<bool>> UpdateOrder(int Id,OrdersAddDto dto);

    }
}
