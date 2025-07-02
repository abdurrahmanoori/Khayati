using Entities.Data;
using Entities;
using Repositories.Base;
using RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using Khayati.Core.Domain.Entities;

namespace Repositories
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
