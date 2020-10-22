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
    public class BudgetSubDetailManager : BaseManager<BudgetSubDetail>, IBudgetSubDetailManager
    {
        IBudgetSubDetailDal _budgetSubDetailDal;

        public BudgetSubDetailManager(IBudgetSubDetailDal budgetSubDetailDal) : base(budgetSubDetailDal)
        {
            _budgetSubDetailDal = budgetSubDetailDal;
        }

    }

}
