using Entities;
using Entities.Data;
using Khayati.Infrastructure.Repositories.Base;
using RepositoryContracts;

namespace Khayati.Infrastructure.Repositories
{
    public class EmbellishmentTypeRepository:GenericRepository<EmbellishmentType>,IEmbellishmentTypeRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public EmbellishmentTypeRepository(ApplicationDbContext dbContext) : base(dbContext)  
            
        {
            _dbcontext = dbContext;
        }


    }
}
