﻿using Entities.Data;
using Khayati.Core.Domain.Entities;
using Khayati.Core.Domain.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Khayati.Infrastructure.Repositories.Base;

namespace Khayati.Infrastructure.Repositories
{
    public class FabricRepository : GenericRepository<Fabric>,IFabricRepository
    {

        private readonly ApplicationDbContext _dbContext;
        public FabricRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
