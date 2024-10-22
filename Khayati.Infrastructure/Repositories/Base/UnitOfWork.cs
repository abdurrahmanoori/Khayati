using Entities.Data;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using RepositoryContracts.Base;

namespace Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
           CustomerRepository = new CustomerRepository(db);
            MeasurementRepository = new MeasurementRepository(db);
            EmbellishmentTypeRepository = new EmbellishmentTypeRepository(db);
            EmbellishmentRepository = new EmbellishmentRepository(db);
            OrderRepository = new OrderRepository(db);
            
        }
        
         public ICustomerRepository CustomerRepository { get; private set; }
         public IMeasurementRepository MeasurementRepository { get; private set; }
         public IEmbellishmentRepository EmbellishmentRepository { get; private set; }
         public IEmbellishmentTypeRepository EmbellishmentTypeRepository { get; private set; }
         public IOrderRepository OrderRepository { get; private set; }
         

        public async Task SaveChanges(CancellationToken cancellationToken)
        {



            //var taxPayer = this.context.TAX_PAYER.Where(x => x.TIN_APPLICATION_NO == 1110001).FirstOrDefault();
            //taxPayer.FISCAL_YEAR.LastOrDefault().FISCAL_YEAR_TO = 21;
            
            //// var taxP = this.context.Entry(test);
            var entities = _db.ChangeTracker.Entries();

            var added = entities.Where(x => x.State == EntityState.Added).ToList();
            var modified = entities.Where(x => x.State == EntityState.Modified).ToList();
            var removed = entities.Where(x => x.State == EntityState.Deleted).ToList();
            var detached = entities.Where(x => x.State == EntityState.Detached).ToList();
            var unchanged = entities.Where(x => x.State == EntityState.Unchanged).ToList();

            int x = 12;

            //var entriesWithState = this.context.ChangeTracker.Entries()
            //         .Select(e => new
            //         {
            //             Entity = e.Entity,
            //             State = e.State

            //         })
            //         .ToList();




            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
