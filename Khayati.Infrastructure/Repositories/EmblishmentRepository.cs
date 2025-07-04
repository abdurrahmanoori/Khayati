﻿using Entities;
using Entities.Data;
using Khayati.Core.DTO.Embellishment;
using Microsoft.EntityFrameworkCore;
using Repositories.Base;
using RepositoryContracts;

namespace Repositories
{
    public class EmbellishmentRepository : GenericRepository<Embellishment>, IEmbellishmentRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public EmbellishmentRepository(ApplicationDbContext dbContext) : base(dbContext)

        {
            _dbcontext = dbContext;
        }

        public async Task<IEnumerable<Embellishment>> GetEmbellishmentListByOrderIdAsync(int orderId)
        {
            //var totalEmbellishmentCostQuery = (from od in _dbcontext.OrderDesigns
            //                                  join e in _dbcontext.Embellishment
            //                                  on od.EmbellishmentId equals e.EmbellishmentId
            //                                  where od.OrderId == orderId
            //                                  select e.Cost).Sum();

            var embellishmentList = await (from od in _dbcontext.OrderDesigns
                                           join e in _dbcontext.Embellishment
                                           on od.EmbellishmentId equals e.EmbellishmentId
                                           where od.OrderId == orderId &&
                                           od.EmbellishmentId != null
                                           select e).ToListAsync();

            return embellishmentList;


            var totalEmbellishmentCost = _dbcontext.OrderDesigns
               .Where(od => od.OrderId == orderId && od.EmbellishmentId != null)
               .SumAsync(od => od.Embellishment.Cost ?? 0);


            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EmellishmentResponseDetailsDto>> GetEmellishmentResponseDetailList()
        {
            var query = await (
                from e in _dbcontext.Embellishment
                join et in _dbcontext.EmbellishmentTypes
                    on e.EmbellishmentTypeId equals et.EmbellishmentTypeId
                select new EmellishmentResponseDetailsDto
                {
                    EmbellishmentId = e.EmbellishmentId,
                    Name = e.Name,
                    Description = e.Description,
                    //EmbellishmentTypeName = et.Name,
                    Cost = e.Cost,
                }).ToListAsync();
            return query;
        }
    }
}
