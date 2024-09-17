using Entities;
using Entities.Data;
using Repositories.Base;
using RepositoryContracts;

namespace Repositories
{
    public class EmbellishmentmentRepository:GenericRepository<Embellishmentment>,IEmbellishmentmentRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public EmbellishmentmentRepository(ApplicationDbContext dbContext) : base(dbContext)  
            
        {
            _dbcontext = dbContext;
        }


    }
}
