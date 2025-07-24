using Entities;
using Entities.Data;
using Khayati.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Khayati.Infrastructure.Repositories
{
    class MeasurementRepository : GenericRepository<Measurement>, IMeasurementRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public MeasurementRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Measurement> GetLatestMeasurementByCustomerIdAsync(int customerId)
        {
            var customer = await _dbcontext.Measurements.Where(x => x.CustomerId == customerId)
                .OrderByDescending(x => x.MeasurementId).FirstOrDefaultAsync();

            return customer!;
        }
    }
}
