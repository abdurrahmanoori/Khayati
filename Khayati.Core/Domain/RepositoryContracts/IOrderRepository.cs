using RepositoryContracts.Base;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        public  Task<Order> GetOrderWithDetailsAsync(int orderId);
    }
}
