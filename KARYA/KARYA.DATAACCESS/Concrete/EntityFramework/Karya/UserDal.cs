using KARYA.CORE.Concrete.EntityFramework;
using KARYA.DATAACCESS.Abstract.Karya;
using KARYA.DATAACCESS.Concrete.EntityFramework.Context;
using KARYA.MODEL.Entities;

namespace KARYA.DATAACCESS.Concrete.EntityFramework
{
    public class UserDal : EfRepository<Users,KaryaContext>,IUserDal
    {
    }
}
