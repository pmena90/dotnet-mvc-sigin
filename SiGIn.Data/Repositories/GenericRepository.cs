using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SiGIn.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected SiGInContext _context;

        public GenericRepository(SiGInContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T t)
        {
            await _context.Set<T>().AddAsync(t);
            //await _context.SaveChangesAsync();
            return t;
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().SingleOrDefault(match);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(match);
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().Where(match).ToListAsync();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T t, object key)
        {
            if (t == null)
                return null;
            T exist = null;
            if (key.GetType() == typeof(int[]))
            {
                exist = await _context.Set<T>().FindAsync(((int[])key)[0], ((int[])key)[1]);
            }
            else
            {
                exist = await _context.Set<T>().FindAsync(key);
            }
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(t);
                //await _context.SaveChangesAsync();
            }
            return exist;
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = _context.Set<T>();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }

            return queryable;
        }

        public IQueryable<T> QueryAll()
        {
            return _context.Set<T>();
        }

        public async Task AddRangeAsync(List<T> t)
        {
            await _context.Set<T>().AddRangeAsync(t);
        }
    }
}
