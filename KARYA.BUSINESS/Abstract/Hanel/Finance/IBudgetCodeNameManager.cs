using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Dtos.Hanel.Finance.Budget;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Abstract.Hanel.Finance
{
    public interface IBudgetCodeNameManager
    {
        Task<IDataResult<IEnumerable<BudgetCodeName>>> List();
    }
}
