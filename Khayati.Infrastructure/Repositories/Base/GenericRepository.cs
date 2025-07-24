using Entities.Data;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> dbSet;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = _dbContext.Set<T>();
        }

        public async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
        }
        public async Task Update(T entity)
        {
            dbSet.Update(entity);
        }
        //public async Task AddRanges(List<T> entity)
        //{
        //    await dbSet.AddRangeAsync(entity);
        //}

        public Task Remove(T entity)
        {
            dbSet.Remove(entity);
            return Task.CompletedTask;
        }
        public async Task<IList<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)// If requested records are based on a condation, then this block will execute.
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.ToListAsync();
        }

        // public async Task<IEnumerable<T>> GetAll(
        //Expression<Func<T, bool>>? filter = null,
        //params Expression<Func<T, object>>[] includeProperties)
        // {
        //     IQueryable<T> query = dbSet;

        //     if (filter != null)
        //     {
        //         query = query.Where(filter);
        //     }

        //     // Include each property using the provided expressions
        //     foreach (var includeProperty in includeProperties)
        //     {
        //         query = query.Include(includeProperty);
        //     }

        //     return await query.ToListAsync();
        // }

        public async Task<T?> GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true)
        {

            IQueryable<T> query;

            if (tracked)
            {
                query = dbSet;
                //this us comment
            }
            else
            {
                query = dbSet.AsNoTracking();
            }

            query = query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
          
            var result = await query.FirstOrDefaultAsync();
            if (result == null)
            {
                return null;
                //throw new ArgumentException($"No {typeof(T).Name}s found matching the filter. and this message comes form generic repository.");
            }

            return result;
        }

        public async Task<T?> GetById(int Id)
        {
            return await dbSet.FindAsync(Id);

        }

        public IQueryable<T> GetAllQueryable(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)// If requested records are based on a condation, then this block will execute.
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return  query;
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
        {
            return dbSet.AnyAsync(filter);
        }

        //public Task RemoveRange(IEnumerable<T> entity)
        //{
        //    dbSet.RemoveRange(entity);
        //    return Task.CompletedTask;
        //}


    }
}
