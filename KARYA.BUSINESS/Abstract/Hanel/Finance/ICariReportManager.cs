using KARYA.BUSINESS.Abstract.Base;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Common.Auth;
using KARYA.MODEL.Common.HanelApp.Finance;
using KARYA.MODEL.Common.HanelApp.PlReport;
using KARYA.MODEL.Dtos;
using KARYA.MODEL.Dtos.CariReport;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Abstract.Hanel.Finance
{
    public interface ICariReportManager
    {
        Task<IDataResult<IEnumerable<CariReportTitle>>> GetCariReportTitles();

        Task<IDataResult<IEnumerable<CariReportSubGroup>>> GetCariReportSubGroup(CariReportFilterModel cariReportFilterModel);

        Task<IDataResult<IEnumerable<CariReportSubGroupDetail>>> GetCariReportSubGroupDetail(CariReportFilterModel cariReportFilterModel);

        Task<IDataResult<IEnumerable<CariReportSubGroupDetail>>> GetCariReportSubGroupDetailFromFisNo(CariReportFilterModel cariReportFilterModel);
    }
}

