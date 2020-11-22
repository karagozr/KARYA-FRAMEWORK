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
    public class ActualCostManager : DapperBaseDal, IActualCostManager 
    {
        public async Task<IDataResult<IEnumerable<ActualCostWithMonths>>> GetActualCostWithMonths(string projectCode,short year, string currency)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"select * from TFunc_GetActualOfProject('{projectCode}',{year},'{currency}')";

                    var data = await connection.QueryAsync<ActualCostWithMonths>(queryString);
                   
                    return new SuccessDataResult<IEnumerable<ActualCostWithMonths>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<ActualCostWithMonths>>(ex.Message);
            }
        }


    }
}
