using Entities;
using Entities.Data;
using Repositories.Base;
using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    class MeasurementRepository:GenericRepository<Measurement>,IMeasurementRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public MeasurementRepository(ApplicationDbContext dbcontext):base(dbcontext) 
        {
            _dbcontext = dbcontext;
        }

    }
}
