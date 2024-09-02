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
        //ISurveyRepository SurveyRepository { get; }
        Task SaveChanges(CancellationToken cancellationToken);

    }
}
