using KARYA.BUSINESS.Abstract.Hanel.Finance;
using KARYA.BUSINESS.Concrete.Base;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Abstract;
using KARYA.DATAACCESS.Abstract.Hanel;
using KARYA.DATAACCESS.Abstract.Hanel.Finance;
using KARYA.MODEL.Entities.Finance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Concrete.Hanel.Finance
{
    public class BudgetManager : BaseManager<Budget>, IBudgetManager
    {
        IBudgetDal _budgetDal;

        public BudgetManager(IBudgetDal budgetDal) : base(budgetDal)
        {
            _budgetDal = budgetDal;
        }

    }

}
