using KARYA.BUSINESS.Abstract.Hanel.Finance;
using KARYA.BUSINESS.Concrete.Base;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Abstract;
using KARYA.DATAACCESS.Abstract.Hanel;
using KARYA.MODEL.Entities.Finance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Concrete.Hanel.Finance
{
    public class PivotReportTemplateManager : BaseManager<PivotReportTemplate>, IPivotReportTemplateManager
    {
        IPivotReportTemplateDal _pivotReportTemplateDal;
        
        public PivotReportTemplateManager(IPivotReportTemplateDal pivotReportTemplateDal) : base(pivotReportTemplateDal)
        {
            _pivotReportTemplateDal = pivotReportTemplateDal;
        }

        public async Task<IDataResult<IEnumerable<PivotReportTemplate>>> GetAll()
        {
            IDataResult<IEnumerable<PivotReportTemplate>> result;

            try
            {
                var data = await _pivotReportTemplateDal.List(null);
                result = new SuccessDataResult<IEnumerable<PivotReportTemplate>>(data);
            }
            catch (Exception ex)
            {
                result = new ErrorDataResult<IEnumerable<PivotReportTemplate>>(null, ex.Message);
            }

            return result;
        }

        
    }
}
