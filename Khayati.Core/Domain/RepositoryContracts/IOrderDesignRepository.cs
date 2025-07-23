using Entities;
using Khayati.Core.DTO.OrderGarmentEmbellishments;
using RepositoryContracts.Base;

namespace RepositoryContracts
{
    public interface IOrderEmbellishmentRepository : IGenericRepository<OrderGarmentEmbellishmentDto>
    {
     public Task<IEnumerable<OrderGarmentEmbellishmentDto>> GetOrderEmbellishmentListByOrderIdAsync(int orderId);
    }
}
