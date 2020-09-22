using KARYA.BUSINESS.Abstract;
using KARYA.BUSINESS.Abstract.Karya;
using KARYA.BUSINESS.Concrete.Base;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Abstract.Karya;
using KARYA.DATAACCESS.Concrete.EntityFramework;
using KARYA.MODEL.Common.Auth;
using KARYA.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Concrete.Karya
{
    public class UserManager : BaseManager<Users>, IUserManager
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal) : base(userDal)
        {
            _userDal = userDal;
        }

        public async Task<IDataResult<Users>> Login(UserLoginModel userLoginModel)
        {
            IDataResult<Users> result;

            try
            {
                var resultUser = await _userDal.Get(x => x.UserName == userLoginModel.UserName && x.Password == userLoginModel.Password);
                if (resultUser != null)
                    result = new SuccessDataResult<Users>(resultUser);
                else
                    result = new SuccessDataResult<Users>(resultUser,  "User was not found.");
            }
            catch (Exception ex)
            {
                result = new ErrorDataResult<Users>(null, ex.Message);
            }

            return result;
        }
    }
}
