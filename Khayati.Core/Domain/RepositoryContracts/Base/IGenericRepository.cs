using System.Linq.Expressions;

namespace RepositoryContracts.Base
{
    public interface IGenericRepository<T>
    {


        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true);
        Task<T?> GetById(int Id);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

        Task Add(T entity);

        Task Update(T entity);

        Task Remove(T entity);

        //Task RemoveRange(IEnumerable<T> entity);

        //Task AddRanges(List<T> entity);

    }
}
