using KARYA.Core.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.Core.Abstarct
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IResult Add(TEntity entity);

        IResult Update(TEntity entity);

        IResult Delete(TEntity entity);

        IDataResult<TEntity> Find(string filter);

        IDataResult<IEnumerable<TEntity>> List(string filter);

    }
}
