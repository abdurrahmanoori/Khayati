using Entities;
using RepositoryContracts.Base;

namespace RepositoryContracts
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> GetByEmail(string email);

    }
}
