﻿namespace RepositoryContracts.Base
{
    public interface IUnitOfWork
    {
        //IProvinceRepository ProvinceRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IMeasurementRepository MeasurementRepository { get; }
        IEmbellishmentRepository EmbellishmentRepository { get; }
        IOrderDesignRepository OrderDesignRepository { get; }
        IEmbellishmentTypeRepository EmbellishmentTypeRepository { get; }
        IOrderRepository OrderRepository { get; }

        Task SaveChanges(CancellationToken cancellationToken);

    }
}
