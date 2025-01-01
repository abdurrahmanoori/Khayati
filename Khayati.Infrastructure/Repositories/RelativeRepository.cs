using Entities.Data;
using Khayati.Core.Domain.Entities;
using Repositories.Base;
using RepositoryContracts;

namespace Repositories
{
    public class RelativeRepository : GenericRepository<Relative>, IRelativeRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public RelativeRepository(ApplicationDbContext dbContext) : base(dbContext)

        {
            _dbcontext = dbContext;
        }

        //public async Task<IEnumerable<Relative>> GetRelativeListByOrderIdAsync(int orderId)
        //{
        //    //var totalRelativeCostQuery = (from od in _dbcontext.OrderDesigns
        //    //                                  join e in _dbcontext.Relative
        //    //                                  on od.RelativeId equals e.RelativeId
        //    //                                  where od.OrderId == orderId
        //    //                                  select e.Cost).Sum();

        //    var RelativeList = await (from od in _dbcontext.OrderDesigns
        //                                   join e in _dbcontext.Relative
        //                                   on od.RelativeId equals e.RelativeId
        //                                   where od.OrderId == orderId &&
        //                                   od.RelativeId != null
        //                                   select e).ToListAsync();

        //    return RelativeList;


        //    var totalRelativeCost = _dbcontext.OrderDesigns
        //       .Where(od => od.OrderId == orderId && od.RelativeId != null)
        //       .SumAsync(od => od.Relative.Cost ?? 0);


        //    throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<EmellishmentResponseDetailsDto>> GetEmellishmentResponseDetailList( )
        //{
        //    var query = await (
        //        from e in _dbcontext.Relative
        //        join et in _dbcontext.RelativeTypes
        //            on e.RelativeTypeId equals et.RelativeTypeId
        //        select new EmellishmentResponseDetailsDto
        //        {
        //            RelativeId = e.RelativeId,
        //            RelativeName = e.Name,
        //            RelativeDescription = e.Description,
        //            RelativeTypeName = et.Name,
        //            Cost = e.Cost,
        //        }).ToListAsync();
        //    return query;
        //}
    }
}
