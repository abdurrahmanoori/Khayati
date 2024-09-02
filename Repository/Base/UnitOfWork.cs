using Entities.Data;
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
        //private readonly ISurveyRepository SurveyRepository;
        //private IPatientTypeRepository _patientTypeRepository;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
           // SurveyRepository = new SurveyRepository(db);
            // ProvinceRepository = new ProvinceRepository(db);
        }

       // public ISurveyRepository SurveyRepository { get; private set; }

        public async Task SaveChanges(CancellationToken cancellationToken)
        {
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
