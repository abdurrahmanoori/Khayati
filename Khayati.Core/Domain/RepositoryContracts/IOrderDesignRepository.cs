using Entities;
using RepositoryContracts.Base;

namespace RepositoryContracts
{
    public interface IOrderEmbellishmentRepository : IGenericRepository<OrderGarmentEmbellishment>
    {
     public Task<IEnumerable<OrderGarmentEmbellishment>> GetOrderEmbellishmentListByOrderIdAsync(int orderId);
    }
}
