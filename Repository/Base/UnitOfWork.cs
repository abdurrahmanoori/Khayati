using Entities.Data;
using RepositoryContracts;
using RepositoryContracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            EmblishTypeRepository = new EmblishTypeRepository(db);
            EmblishRepository = new EmblishRepository(db);
            OrdersRepository = new OrdersRepository(db);
            
        }
        
         public ICustomerRepository CustomerRepository { get; private set; }
         public IMeasurementRepository MeasurementRepository { get; private set; }
         public IEmblishRepository EmblishRepository { get; private set; }
         public IEmblishTypeRepository EmblishTypeRepository { get; private set; }
         public IOrdersRepository OrdersRepository { get; private set; }
         

        public async Task SaveChanges(CancellationToken cancellationToken)
        {
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
