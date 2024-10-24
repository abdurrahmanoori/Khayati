using Entities;
using Entities.Data;
using Microsoft.EntityFrameworkCore;
using Repositories.Base;
using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public OrderRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        // Method to fetch order details with related entities
        public async Task<Order> GetOrderWithDetailsAsync(int orderId)
        {
            return await _dbcontext.Orders
                                 .Include(o => o.Payments)
                                 .Include(o => o.OrderDesigns)
                                 .ThenInclude(d => d.Embellishment)
                                 .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

    }
}
