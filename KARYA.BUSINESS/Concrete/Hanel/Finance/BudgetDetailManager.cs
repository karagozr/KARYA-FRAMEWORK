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
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Concrete.Hanel.Finance
{
    public class BudgetDetailManager : BaseManager<BudgetDetail>, IBudgetDetailManager
    {
        IBudgetDetailDal _budgetDetailDal;

        public BudgetDetailManager(IBudgetDetailDal budgetDetailDal) : base(budgetDetailDal)
        {
            _budgetDetailDal = budgetDetailDal;
        }

        public async Task<IDataResult<IEnumerable<BudgetWithMonthsDto>>> ListOfBudgetWithMonths(string projectCode, short budgetYear )
        {
            IDataResult<IEnumerable<BudgetWithMonthsDto>> result;

            try
            {
                var data = await _budgetDetailDal.ListOfBudgetWithMonths(x => x.Budget.ProjectCode == projectCode && x.Budget.BudgetYear == budgetYear);

                result = new SuccessDataResult<IEnumerable<BudgetWithMonthsDto>>(data);
            }
            catch (Exception ex)
            {
                result = new ErrorDataResult<IEnumerable<BudgetWithMonthsDto>>(null,ex.Message);
            }

            return result;
        }

    }

}
