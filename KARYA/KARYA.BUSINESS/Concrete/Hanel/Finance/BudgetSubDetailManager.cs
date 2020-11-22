using KARYA.BUSINESS.Abstract.Hanel.Finance;
using KARYA.BUSINESS.Concrete.Base;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Abstract;
using KARYA.DATAACCESS.Abstract.Hanel;
using KARYA.DATAACCESS.Abstract.Hanel.Finance;
using KARYA.MODEL.Dtos.Hanel.Finance.Budget;
using KARYA.MODEL.Entities.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Concrete.Hanel.Finance
{
    public class BudgetSubDetailManager : BaseManager<BudgetSubDetail>, IBudgetSubDetailManager
    {
        IBudgetSubDetailDal _budgetSubDetailDal;

        public BudgetSubDetailManager(IBudgetSubDetailDal budgetSubDetailDal) : base(budgetSubDetailDal)
        {
            _budgetSubDetailDal = budgetSubDetailDal;
        }

        public async Task<IDataResult<IEnumerable<BudgetSubDetailDto>>> Select(IEnumerable<int> budgetIds)
        {
            try
            {
                var result = await _budgetSubDetailDal.ListWithSubCode(x => budgetIds.Contains(x.BudgetId));

                return new SuccessDataResult<IEnumerable<BudgetSubDetailDto>>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<BudgetSubDetailDto>>(null,ex.Message);
            }
            
        }
    }

}
