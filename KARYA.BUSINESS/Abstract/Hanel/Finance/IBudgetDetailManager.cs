﻿using KARYA.BUSINESS.Abstract.Base;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Dtos.Hanel.Finance.Budget;
using KARYA.MODEL.Entities.Finance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Abstract.Hanel.Finance
{
    public interface IBudgetDetailManager : IBaseManager<BudgetDetail>
    {
        Task<IDataResult<IEnumerable<BudgetAndActualWithMonthsDto>>> ListOfBudgetAndActualWithMonths(string projectCode, short budgetYear, short actualYear, string currencyCode);
    }
}
