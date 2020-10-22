using KARYA.BUSINESS.Abstract.Base;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Abstract;
using KARYA.MODEL.Entities;
using KARYA.MODEL.Entities.Base.Abstarct;
using KARYA.MODEL.Entities.Base.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Concrete.Base
{
    public class BaseManager<TEntity> : IBaseManager<TEntity> where TEntity : BaseEntity
    {
        private int _identityId=0;
        readonly IBaseDal<TEntity> _baseDal;
        public BaseManager(IBaseDal<TEntity> baseDal)
        {
            _baseDal = baseDal;
        }

        public int ScopeIdentity()
        {
            return _identityId;
        }

        public async Task<IResult> Add(TEntity entity)
        {
            IResult result;
            try
            {
                if (typeof(ILogEntity).IsAssignableFrom(typeof(ILogEntity)))
                {
                    foreach (var item in typeof(TEntity).GetFields().Where(x=> typeof(ILogEntity).GetFields().Select(x=>x.Name).Contains(x.Name)))
                    {
                        if (item.Name == "CreatedTime")
                            item.SetValue(null, DateTime.Now);
                        if (item.Name == "UserId")
                            item.SetValue(null, 0);

                    } 
                }
                await _baseDal.Add(entity);
                _identityId = _baseDal.SCOPE_IDENTY_ID;
                result = new SuccessResult("Adding was succesed");
            }
            catch (Exception ex)
            {
                result = new ErrorResult(ex.Message);
            }

            return result;
        }

        public async Task<IResult> AddList(IEnumerable<TEntity> entities)
        {
            IResult result;
            try
            {
                if (typeof(ILogEntity).IsAssignableFrom(typeof(ILogEntity)))
                {
                    foreach (var item in typeof(TEntity).GetFields().Where(x => typeof(ILogEntity).GetFields().Select(x => x.Name).Contains(x.Name)))
                    {
                        if (item.Name == "CreatedTime")
                            item.SetValue(null, DateTime.Now);
                        if (item.Name == "UserId")
                            item.SetValue(null, 0);

                    }
                }
                await _baseDal.Add(entities);
                result = new SuccessResult("List Adding was succesed");
            }
            catch (Exception ex)
            {
                result = new ErrorResult(ex.Message);
            }

            return result;
        }

        public async Task<IResult> Delete(TEntity entity)
        {
            IResult result;
            try
            {
                await _baseDal.Delete(entity);
                result = new SuccessResult("Deleting was succesed");
                _identityId = _baseDal.SCOPE_IDENTY_ID;
            }
            catch (Exception ex)
            {
                result = new ErrorResult(ex.Message);
            }

            return result;
        }

        public async Task<IDataResult<TEntity>> GetById(int id)
        {
            IDataResult<TEntity> result;
            try
            {
                var entity = await _baseDal.Get(x=>x.Id==id);
                result = new SuccessDataResult<TEntity>(entity, "Update was succesed");
            }
            catch (Exception ex)
            {
                result = new SuccessDataResult<TEntity>(ex.Message);
            }

            return result;
        }

        public async Task<IResult> Update(TEntity entity)
        {
            IResult result;
            try
            {
                await _baseDal.Update(entity);
                result = new SuccessResult("Update was succesed");
                _identityId = _baseDal.SCOPE_IDENTY_ID;
            }
            catch (Exception ex)
            {
                result = new ErrorResult(ex.Message);
            }

            return result;
        }

        public async Task<IResult> UpdateList(IEnumerable<TEntity> entities)
        {
            IResult result;
            try
            {
                await _baseDal.Update(entities);
                result = new SuccessResult("List Update was succesed");
            }
            catch (Exception ex)
            {
                result = new ErrorResult(ex.Message);
            }

            return result;
        }


    }
}
