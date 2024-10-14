using Khayati.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.ServiceContracts
{
    public interface IOrdersService
    {
        public Task<OrdersAddDto> AddOrders(OrdersAddDto addOrdersDto);
        public Task<OrdersResponseDto> GetOrdersById(int? OrdersId);

        public Task<IEnumerable<OrdersResponseDto>> GetOrdersList();

        public Task<OrdersResponseDto> DeleteOrders(int? OrdersId);
        // public Task<OrdersResponseDto> UpdateOrders(int? OrdersId);

    }
}
