using Entities;
using RepositoryContracts.Base;

namespace RepositoryContracts
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<double> GetTotalPaymentsByOrderIdAsync(int orderId);

    }
}
