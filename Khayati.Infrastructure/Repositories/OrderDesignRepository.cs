using Entities;
using Entities.Data;
using Microsoft.EntityFrameworkCore;
using Repositories.Base;
using RepositoryContracts;

namespace Repositories
{
    public class OrderDesignRepository : GenericRepository<OrderDesign>, IOrderDesignRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public OrderDesignRepository(ApplicationDbContext dbContext) : base(dbContext)

        {
            _dbcontext = dbContext;
        }

        public async Task<IEnumerable<OrderDesign>> GetOrderDesignListByOrderIdAsync(int orderId)
        {
           var orderDesignList = from od in _dbcontext.OrderDesigns
                                 where od.OrderId == orderId
                                 select od;
            return await orderDesignList.ToListAsync();
        }
    }
}
