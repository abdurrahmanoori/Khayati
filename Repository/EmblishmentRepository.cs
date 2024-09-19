using Entities;
using Entities.Data;
using Repositories.Base;
using RepositoryContracts;

namespace Repositories
{
    public class EmbellishmentRepository:GenericRepository<Embellishment>,IEmbellishmentRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public EmbellishmentRepository(ApplicationDbContext dbContext) : base(dbContext)  
            
        {
            _dbcontext = dbContext;
        }


    }
}
