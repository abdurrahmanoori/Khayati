using RepositoryContracts.Base;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Khayati.Core.DTO.Orders;

namespace RepositoryContracts
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<CustomerOrderResponseDto?>>
            GetOrderListByCustomerId(int customerId);

        public  Task<Order>
            GetOrderWithDetailsAsync(int orderId);
    }
}
