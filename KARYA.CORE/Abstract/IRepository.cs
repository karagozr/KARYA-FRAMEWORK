using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.CORE.Abstarct
{
    public interface IRepository<TEntity> where TEntity : class
    {
        int SCOPE_IDENTY_ID { get; set; }
        Task<TEntity> Get(Expression<Func<TEntity, bool>> filter);

        Task<IEnumerable<TEntity>> List(Expression<Func<TEntity, bool>> filter);

        Task<int> Count(Expression<Func<TEntity, bool>> filter);

        Task Add(TEntity entity);

        Task Add(IEnumerable<TEntity> entities);

        Task Update(TEntity entity);

        Task Update(IEnumerable<TEntity> entities);

        Task Update(TEntity entity, IEnumerable<string> fields);

        Task Delete(TEntity entity);

        Task Delete(IEnumerable<TEntity> entities);
    }
}
