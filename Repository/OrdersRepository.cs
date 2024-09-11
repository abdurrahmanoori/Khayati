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
    class OrdersRepository : GenericRepository<Orders>, IOrdersRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public OrdersRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

    }
}
