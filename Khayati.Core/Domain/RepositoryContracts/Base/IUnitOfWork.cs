using Khayati.Core.Domain.RepositoryContracts;

namespace RepositoryContracts.Base
{
    public interface IUnitOfWork
    {
        //IProvinceRepository ProvinceRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IMeasurementRepository MeasurementRepository { get; }
        IEmbellishmentRepository EmbellishmentRepository { get; }
        IRelativeRepository RelativeRepository { get; }
        IEmbellishmentTypeRepository EmbellishmentTypeRepository { get; }
        IOrderRepository OrderRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        IGarmentRepository GarmentRepository { get; }
        IFabricRepository FabricRepository { get; }
        Task SaveChanges(CancellationToken cancellationToken= default);
    }
}
