using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SiGIn.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync();

        Task<T> GetAsync(int id);

        Task<T> AddAsync(T t);

        T Find(Expression<Func<T, bool>> match);

        Task<T> FindAsync(Expression<Func<T, bool>> match);

        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);

        Task<int> DeleteAsync(T entity);

        Task<T> UpdateAsync(T t, object key);

        Task<int> CountAsync();

        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> QueryAll();

        Task AddRangeAsync(List<T> t);
    }
}
