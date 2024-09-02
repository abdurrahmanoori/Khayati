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
            // ProvinceRepository = new ProvinceRepository(db);
        }

         public ICustomerRepository CustomerRepository { get; private set; }

        public async Task SaveChanges(CancellationToken cancellationToken)
        {
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
