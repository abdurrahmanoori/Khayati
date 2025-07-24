using Entities;
using Entities.Data;
using Khayati.Infrastructure.Repositories.Base;
using RepositoryContracts;

namespace Khayati.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
