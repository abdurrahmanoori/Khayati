using Entities.Data;
using Entities;
using Repositories.Base;
using RepositoryContracts;

namespace Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Customer> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
