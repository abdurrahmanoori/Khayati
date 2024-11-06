using Entities;
using RepositoryContracts.Base;

namespace RepositoryContracts
{
    public interface IOrderDesignRepository : IGenericRepository<OrderDesign>
    {
     public Task<IEnumerable<OrderDesign>> GetOrderDesignListByOrderIdAsync(int orderId);
    }
}
