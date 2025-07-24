using Entities.Data;
using Khayati.Core.Domain.Entities;
using Khayati.Infrastructure.Repositories.Base;
using RepositoryContracts;

namespace Khayati.Infrastructure.Repositories
{
    public class GarmentRepository : GenericRepository<Garment>, IGarmentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public GarmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
