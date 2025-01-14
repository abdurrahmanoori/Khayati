using Entities;
using Khayati.Core.DTO.Embellishment;
using RepositoryContracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts
{
    public interface IEmbellishmentRepository:IGenericRepository<Embellishment>
    {
     public Task<IEnumerable<Embellishment>> GetEmbellishmentListByOrderIdAsync(int orderId);
        Task<IEnumerable<EmellishmentResponseDetailsDto>> GetEmellishmentResponseDetailList( );
    }
}
