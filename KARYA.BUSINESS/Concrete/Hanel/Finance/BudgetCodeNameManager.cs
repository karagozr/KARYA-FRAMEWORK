using Dapper;
using KARYA.BUSINESS.Abstract.Hanel.Finance;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Concrete.Dapper;
using KARYA.MODEL.Dtos.Hanel.Finance.Budget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Concrete.Hanel.Finance
{
    public class BudgetCodeNameManager : DapperBaseDal, IBudgetCodeNameManager
    {
        public async Task<IDataResult<IEnumerable<BudgetCodeName>>> List()
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var data = await connection.QueryAsync<BudgetCodeName>("select * from Vw_PlReportCodes");

                    return new SuccessDataResult<IEnumerable<BudgetCodeName>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<BudgetCodeName>>(ex.Message);
            }
        }
    }
}
