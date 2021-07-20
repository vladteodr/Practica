using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace webapi5.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(Guid id);
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

    }
}
