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
        Task<IDataResult<TEntity>> GetById(int id);

        Task<IResult> Add(TEntity entity);

        Task<IResult> Update(TEntity entity);

        Task<IResult> Delete(TEntity entity);

    }
}
