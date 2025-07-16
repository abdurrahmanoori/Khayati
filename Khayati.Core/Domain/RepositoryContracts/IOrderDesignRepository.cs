using Entities;
using RepositoryContracts.Base;

namespace RepositoryContracts
{
    public interface IOrderEmbellishmentRepository : IGenericRepository<OrderEmbellishment>
    {
     public Task<IEnumerable<OrderEmbellishment>> GetOrderEmbellishmentListByOrderIdAsync(int orderId);
    }
}
