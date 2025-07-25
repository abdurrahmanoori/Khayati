﻿using Entities.Data;
using Khayati.Core.Domain.RepositoryContracts;
using RepositoryContracts;
using RepositoryContracts.Base;

namespace Khayati.Infrastructure.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;


        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            //CustomerRepository = new CustomerRepository(db);
            MeasurementRepository = new MeasurementRepository(db);
            //EmbellishmentTypeRepository = new EmbellishmentTypeRepository(db);
            EmbellishmentRepository = new EmbellishmentRepository(db);
            RelativeRepository = new RelativeRepository(db);
            OrderRepository = new OrderRepository(db);
            PaymentRepository = new PaymentRepository(db);

        }

        private ICustomerRepository _customerRepository;
        private IGarmentRepository _garmentRepository;
        private IFabricRepository _fabricRepository;
        public IMeasurementRepository MeasurementRepository { get; private set; }
        public IEmbellishmentRepository EmbellishmentRepository { get; private set; }
        public IRelativeRepository RelativeRepository { get; private set; }
        public IEmbellishmentTypeRepository _embellishmentTypeRepository { get; private set; }
        public IOrderRepository OrderRepository { get; private set; }
        public IPaymentRepository PaymentRepository { get; private set; }

        public IEmbellishmentTypeRepository EmbellishmentTypeRepository =>
            this._embellishmentTypeRepository ??= new EmbellishmentTypeRepository(_db);

        public ICustomerRepository CustomerRepository =>
            _customerRepository ??= new CustomerRepository(_db);

        public IGarmentRepository GarmentRepository =>
            _garmentRepository ??= new GarmentRepository(_db);

        public IFabricRepository FabricRepository =>_fabricRepository ??=
            new FabricRepository(_db);


        public async Task SaveChanges(CancellationToken cancellationToken = default)
        {



            //var taxPayer = this.context.TAX_PAYER.Where(x => x.TIN_APPLICATION_NO == 1110001).FirstOrDefault();
            //taxPayer.FISCAL_YEAR.LastOrDefault().FISCAL_YEAR_TO = 21;

            //// var taxP = this.context.Entry(test);
            //var entities = this.context.ChangeTracker.Entries();

            //var added = entities.Where(x => x.State == EntityState.Added).ToList();
            //var modified = entities.Where(x => x.State == EntityState.Modified).ToList();



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
