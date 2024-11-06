using Entities.Data;
using Entities;
using Repositories.Base;
using RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public PaymentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<decimal> GetTotalPaymentsByOrderIdAsync(int orderId)
        {
            var totalPayments = await _dbContext.Payments
                .Where(p => p.OrderId == orderId)
                .SumAsync(p => p.Amount);
            return totalPayments;
            var query = await (from p in _dbContext.Payments
                               where p.OrderId == orderId
                               select p.Amount).SumAsync();
        }
    }
}
