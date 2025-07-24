using Entities;
using Entities.Data;
using Khayati.Core.DTO.Orders;
using Khayati.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Khayati.Infrastructure.Repositories
{
    internal class OrderRepository(ApplicationDbContext context) : GenericRepository<Order>(context), IOrderRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<CustomerOrderResponseDto?>> GetOrderListByCustomerId(int customerId)
        {
            var query = await (
                from order in _context.Orders
                join customer in _context.Customers on order.CustomerId equals customer.CustomerId
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
        public async Task<Order?> GetOrderWithDetailsAsync(int orderId)
        {
            return await _context.Orders
                                 .Include(o => o.Payments)
                                 .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

    }
}
