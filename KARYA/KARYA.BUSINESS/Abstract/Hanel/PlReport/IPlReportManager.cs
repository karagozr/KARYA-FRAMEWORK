using KARYA.BUSINESS.Abstract.Base;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Common.Auth;
using KARYA.MODEL.Common.HanelApp.PlReport;
using KARYA.MODEL.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Abstract.Hanel.PlReport
{
    public interface IPlReportManager
    {
        Task<IDataResult<IEnumerable<KARYA.MODEL.Dtos.ActualRawData>>> GetRawData(PlReportFilterModel plReportFilterModel);
        Task<IDataResult<KARYA.MODEL.Dtos.PlReport>> GetReport(PlReportFilterModel plReportFilterModel);

        Task<IDataResult<IEnumerable<KARYA.MODEL.Dtos.PlReportWithDetail>>> GetReportWithDetails(PlReportFilterModel plReportFilterModel);

        Task<IDataResult<IEnumerable<KARYA.MODEL.Dtos.ProjectsForPlReportFilter>>> GetProjectsForReportFilter();

        Task<IDataResult<IEnumerable<KARYA.MODEL.Dtos.PlReportDetailForBudgetOrCost>>> GetReportValuesDetails(PlReportFilterModel plReportFilterModel);
    }
}
