using KARYA.BUSINESS.Abstract.Base;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Common.Auth;
using KARYA.MODEL.Common.HanelApp.Finance;
using KARYA.MODEL.Common.HanelApp.PlReport;
using KARYA.MODEL.Dtos;
using KARYA.MODEL.Dtos.CariReport;
using KARYA.MODEL.Dtos.Hanel.Finance.Budget;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Abstract.Hanel.Finance
{
    public interface IActualCostManager
    {
        Task<IDataResult<IEnumerable<ActualCostWithMonths>>> GetActualCostWithMonths(string projectCode,short year, string currency);

    }
}

