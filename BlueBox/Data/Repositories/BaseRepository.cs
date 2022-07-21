using Data.Contexts;
using Data.Repositories.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PCSportsCards.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ApplicationContext _context;
        protected DbSet<T> _entities;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IQueryable<T> FindAllAsync(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entities.AsNoTracking().AsQueryable();
            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);
            return query.Where(exp).AsNoTracking().AsQueryable<T>();
        }


        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entities.AsNoTracking().AsQueryable();
            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);
            return await query.SingleOrDefaultAsync(exp);
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void Add(IEnumerable<T> entities)
        {
            foreach (var item in entities)
            {
                _entities.Add(item);
            }
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public void Update(IEnumerable<T> entities)
        {
            foreach (var item in entities)
            {
                _entities.Update(item);
            }
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }

        public void Remove(IEnumerable<T> entities)
        {
            _entities.RemoveRange(entities);
        }

        public async Task<IList<TEntity>> ExecuteStoredProcedureAsync<TEntity>(string commandText, List<SqlParameter> parameters) where TEntity : class, new()
        {
            return await _context.LoadStoredProc(commandText)
                              .WithSqlParam(parameters)
                             .ExecuteStoredProcAsync<TEntity>();
        }
    }
}
