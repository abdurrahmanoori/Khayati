using Entities;
using Entities.Data;
using Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class EmbellishRepository:GenericRepository<Embellish>
    {
        private readonly ApplicationDbContext _dbcontext;

        public EmbellishRepository(ApplicationDbContext dbContext) : base(dbContext)  
            
        {
            _dbcontext = dbContext;
        }


    }
}
