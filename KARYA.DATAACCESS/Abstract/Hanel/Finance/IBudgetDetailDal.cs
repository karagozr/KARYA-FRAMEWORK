using KARYA.MODEL.Dtos.Hanel.Finance.Budget;
using KARYA.MODEL.Entities.Finance;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.DATAACCESS.Abstract.Hanel.Finance
{
    public interface IBudgetDetailDal : IBaseDal<BudgetDetail>
    {
        Task<IEnumerable<BudgetWithMonthsDto>> ListOfBudgetWithMonths(Expression<Func<BudgetDetail, bool>> filter);
    }
}
