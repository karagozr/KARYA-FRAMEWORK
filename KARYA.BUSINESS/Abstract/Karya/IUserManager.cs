using KARYA.BUSINESS.Abstract.Base;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Common.Auth;
using KARYA.MODEL.Entities;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Abstract.Karya
{
    public interface IUserManager : IBaseManager<Users>
    {
        Task<IDataResult<Users>> Login(UserLoginModel userLoginModel);
    }
}
