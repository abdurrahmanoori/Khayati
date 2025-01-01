using Khayati.Core.Domain.Entities;
using RepositoryContracts.Base;

namespace RepositoryContracts
{
    public interface IRelativeRepository : IGenericRepository<Relative>
    {

        //public Task<IEnumerable<Relative>>
        //       GetRelativeListByOrderIdAsync(int orderId);

        //public Task<IEnumerable<EmellishmentResponseDetailsDto>>
        //      GetEmellishmentResponseDetailList( );
    }
}
