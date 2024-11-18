using Entities;
using Entities.Data;
using Khayati.Core.DTO.Orders;
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

        public async Task<IEnumerable<CustomerOrderResponseDto?>>
            GetOrderListByCustomerId(int customerId)
        {
            var query = await (
                from order in _dbcontext.Orders
                join customer in _dbcontext.Customers on order.CustomerId equals customer.CustomerId
                where order.CustomerId == customerId
                select new CustomerOrderResponseDto
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.Name,
                    LastName = customer.LastName,
                    OrderId = order.OrderId,
                    TotalCost = order.TotalCost,
                    IsPaid = order.IsPaid,
                    OrderDate = order.OrderDate
                }).OrderByDescending(o => o.OrderDate).ToListAsync();
            return query;
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
