using Entities;
using Entities.Data;
using Repositories.Base;
using RepositoryContracts;

namespace Repositories
{
    public class EmblishRepository:GenericRepository<Emblish>,IEmblishRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public EmblishRepository(ApplicationDbContext dbContext) : base(dbContext)  
            
        {
            _dbcontext = dbContext;
        }


    }
}
