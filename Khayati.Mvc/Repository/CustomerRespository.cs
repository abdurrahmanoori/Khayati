using Entities;
using RepositoryContracts;
using System.Linq.Expressions;

namespace Khayati.Mvc.Repository
{
    public class CustomerRespository : ICustomerRepository
    {
        public Task Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAll(Expression<Func<Customer, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetFirstOrDefault(Expression<Func<Customer, bool>> filter, string? includeProperties = null, bool tracked = true)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
