using Dapper;
using KARYA.BUSINESS.Abstract.Hanel.Finance;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Concrete.Dapper;
using KARYA.MODEL.Common.HanelApp.Finance;
using KARYA.MODEL.Dtos;
using KARYA.MODEL.Dtos.CariReport;
using KARYA.MODEL.Dtos.Hanel.Finance.Budget;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Concrete.Hanel.Finance
{
    public class BudgetActualCostManager : DapperBaseDal, IBudgetActualCostManager
    {

        public async Task<IDataResult<IEnumerable<BudgetAndActualWithMonthsDto>>> GetActualBudgetCostWithMonths(string projectCode, short budgetYear, short actualYear, string actualCurrencyCode)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"select * from TFunc_GetBudgetAndActualOfProjectWithMonthly('{projectCode}',{budgetYear},{actualYear},'{actualCurrencyCode}')";

                    var data = await connection.QueryAsync<BudgetAndActualWithMonthsDto>(queryString);
                   
                    return new SuccessDataResult<IEnumerable<BudgetAndActualWithMonthsDto>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<BudgetAndActualWithMonthsDto>>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<ProjectsBudgetListWithStatus>>> GetProjectsBudgetListWithStatus(short budgetYear)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"select * from TFunc_GetListOfProjectsWithBudgetStatus({budgetYear})";

                    var data = await connection.QueryAsync<ProjectsBudgetListWithStatus>(queryString);

                    return new SuccessDataResult<IEnumerable<ProjectsBudgetListWithStatus>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<ProjectsBudgetListWithStatus>>(ex.Message);
            }
        }
    }
}
