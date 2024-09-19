using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts.Base
{
    public interface IUnitOfWork
    {
        //IProvinceRepository ProvinceRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IMeasurementRepository MeasurementRepository { get; }
        IEmbellishmentRepository EmbellishmentRepository { get; }
        IEmbellishmentTypeRepository EmbellishmentTypeRepository { get; }
        IOrderRepository OrderRepository { get; }

        Task SaveChanges(CancellationToken cancellationToken);

    }
}
