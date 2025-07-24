using Entities;
using Entities.Data;
using Khayati.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Khayati.Infrastructure.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public PaymentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<double> GetTotalPaymentsByOrderIdAsync(int orderId)
        {
            var totalPayments = await _dbContext.Payments
                .Where(p => p.OrderId == orderId)
                .SumAsync(p =>(double) p.Amount);

            return totalPayments;
            var query = await (from p in _dbContext.Payments
                               where p.OrderId == orderId
                               select p.Amount).SumAsync();
        }
    }
}
