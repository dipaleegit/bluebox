using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> FindAllAsync(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includes);
        void Add(T entity);
        void Add(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Remove(T entity);
        void Remove(IEnumerable<T> entities);
        Task<IList<TEntity>> ExecuteStoredProcedureAsync<TEntity>(string commandText, List<SqlParameter> parameters) where TEntity : class, new();
    }
}
