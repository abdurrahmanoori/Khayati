using Entities;
using RepositoryContracts.Base;

namespace RepositoryContracts
{
    public interface IEmbellishmentRepository:IGenericRepository<Embellishment>
    {
     public Task<IEnumerable<Embellishment>> GetEmbellishmentListByOrderIdAsync(int orderId);


    }
}
