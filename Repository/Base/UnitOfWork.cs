using Entities.Data;
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
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
