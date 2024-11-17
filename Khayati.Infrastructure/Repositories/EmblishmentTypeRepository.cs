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
    public class EmbellishmentTypeRepository:GenericRepository<EmbellishmentType>,IEmbellishmentTypeRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public EmbellishmentTypeRepository(ApplicationDbContext dbContext) : base(dbContext)  
            
        {
            _dbcontext = dbContext;
        }


    }
}
