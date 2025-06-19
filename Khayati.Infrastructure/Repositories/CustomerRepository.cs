using Entities.Data;
using Entities;
using Repositories.Base;
using RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace Repositories
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
