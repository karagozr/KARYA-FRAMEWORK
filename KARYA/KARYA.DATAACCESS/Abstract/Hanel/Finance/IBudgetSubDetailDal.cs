using KARYA.MODEL.Dtos.Hanel.Finance.Budget;
using KARYA.MODEL.Entities.Finance;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.DATAACCESS.Abstract.Hanel.Finance
{
    public interface IBudgetSubDetailDal : IBaseDal<BudgetSubDetail>
    {
        Task<IEnumerable<BudgetSubDetailDto>> ListWithSubCode(Expression<Func<BudgetSubDetail, bool>> filter);
    }
}
