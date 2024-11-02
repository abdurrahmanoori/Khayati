using Entities;
using RepositoryContracts.Base;

namespace RepositoryContracts
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<decimal> GetTotalPaymentsByOrderIdAsync(int orderId);

    }
}
