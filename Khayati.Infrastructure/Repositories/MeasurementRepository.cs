using Entities;
using Entities.Data;
using Microsoft.EntityFrameworkCore;
using Repositories.Base;
using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
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
                .OrderByDescending(x => x.Measurementid).FirstOrDefaultAsync();

            return customer!;
        }
    }
}
