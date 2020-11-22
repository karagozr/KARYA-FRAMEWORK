using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Entities.Base.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Abstract.Base
{
    public interface IBaseManager<TEntity> where TEntity:BaseEntity
    {
        int ScopeIdentity();
        Task<IDataResult<TEntity>> GetById(int id);

        Task<IResult> Add(TEntity entity);

        Task<IResult> AddList(IEnumerable<TEntity> entities);

        Task<IResult> Update(TEntity entity);

        Task<IResult> UpdateList(IEnumerable<TEntity> entities);

        Task<IResult> Delete(TEntity entity);

    }
}
