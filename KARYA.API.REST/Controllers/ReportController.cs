using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using KARYA.API.REST.Models.Finance;
using KARYA.BUSINESS.Abstract.Hanel.Finance;
using KARYA.BUSINESS.Abstract.Hanel.PlReport;
using KARYA.MODEL.Common.HanelApp.Finance;
using KARYA.MODEL.Common.HanelApp.PlReport;
using KARYA.MODEL.Dtos;
using KARYA.MODEL.Entities.Finance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KARYA.API.REST.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ReportController : Controller
    {
        IPlReportManager _plReportManager;
        IPivotReportTemplateManager _reportTemplateManager;
        ICariReportManager _cariReportManager;
        public ReportController(IPlReportManager plReportManager, IPivotReportTemplateManager reportTemplateManager, ICariReportManager cariReportManager)
        {
            _plReportManager = plReportManager;
            _reportTemplateManager = reportTemplateManager;
            _cariReportManager = cariReportManager;
        }

        [HttpPost("getpl")]
        public async Task<IActionResult> GetPlReportValues(PlReportFilterModel plReportFilterModel)
        {
            var resultData = await _plReportManager.GetReport(plReportFilterModel);

            if (resultData.Success)
            {
                return Ok(resultData.Data);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("getplwithdetail")]
        public async Task<IActionResult> GetPlReportWithDetailValues(PlReportFilterModel plReportFilterModel)
        {
            var resultData = await _plReportManager.GetReportWithDetails(plReportFilterModel);
            foreach (var item in resultData.Data)
            {
                item.SubCode2 = item.SubCode;
            }

            if (resultData.Success)
            {
                return Ok(resultData.Data.ToList());
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("getpldetail")]
        public async Task<IActionResult> GetPlReportDetailValues(PlReportFilterModel plReportFilterModel)
        {
            var resultData = await _plReportManager.GetReportValuesDetails(plReportFilterModel);

            if (resultData.Success)
            {
                return Ok(resultData.Data.ToList());
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("getplfilterdata")]
        public async Task<IActionResult> GetReportFilterData()
        {
            var filterData = await _plReportManager.GetProjectsForReportFilter();

            if (filterData.Success)
            {
                return Ok(filterData.Data.ToList());
            }
            else
            {
                return NoContent();
            }

        }

        [HttpPost("getactualrawdata")]
        public async Task<IActionResult> GetActualRawData()
        {
            var resultData = await _plReportManager.GetRawData(new PlReportFilterModel());

            if (resultData.Success)
            {
                var serializerSettings = new JsonSerializerSettings();
                serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                return Ok(JsonConvert.SerializeObject(resultData.Data, serializerSettings));
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("AddPivotTemplate")]
        public async Task<IActionResult> AddPivotTemplate(PivotTemplateModel pivotTemplateModel)
        {
            var newData = new PivotReportTemplate
            {
                ReportName=pivotTemplateModel.ReportName,
                JsonData=pivotTemplateModel.JsonData
            };

            var result = await _reportTemplateManager.Add(newData);

            if (result.Success == true)
                return Ok(pivotTemplateModel);
            else
                return BadRequest();
        }

        [HttpPost("UpdatePivotTemplate")]
        public async Task<IActionResult> UpdatePivotTemplate(PivotTemplateModel pivotTemplateModel)
        {
            if (pivotTemplateModel.Id == 0) return BadRequest();

            var updateData = new PivotReportTemplate
            {
                Id = pivotTemplateModel.Id,
                ReportName = pivotTemplateModel.ReportName,
                JsonData = pivotTemplateModel.JsonData
            };

            var result = await _reportTemplateManager.Update(updateData);

            if (result.Success == true)
                return Ok(pivotTemplateModel);
            else
                return BadRequest();
        }

        [HttpGet("GetPivotTemplate")]
        public async Task<IActionResult> GetPivotTemplate()
        {

            var result = await _reportTemplateManager.GetAll();

            if (result.Success == true)
                return Ok(result.Data.Select(x=>new { x.Id,x.ReportName,x.JsonData}));
            else
                return BadRequest();
        }

        [HttpGet("CariReport")]
        public async Task<IActionResult> CariReportTitles()
        {
            var result = await _cariReportManager.GetCariReportTitles();

            if (result.Success)
            {
                return Ok(result.Data.ToList());
            }
            else
            {
                return NoContent();
            }

        }

        [HttpGet("CariReport/SubGroup")]
        public async Task<IActionResult> CariReportSubGroup(string kod)
        {
            var result = await _cariReportManager.GetCariReportSubGroup(new CariReportFilterModel {CariKod=kod });

            if (result.Success)
            {
                return Ok(result.Data.ToList());
            }
            else
            {
                return NoContent();
            }

        }

        [HttpGet("CariReport/SubGroup/GrupDetail")]
        public async Task<IActionResult> CariReportSubGroupDetail(string cariKod,string projeKod, string raporHesapKod)
        {
            var result = await _cariReportManager.GetCariReportSubGroupDetail(new CariReportFilterModel { CariKod=cariKod, ProjeKod=projeKod,RaporHesapKod = raporHesapKod } );

            if (result.Success)
            {
                return Ok(result.Data.ToList());
            }
            else
            {
                return NoContent();
            }

        }

        [HttpGet("CariReport/SubGroup/GrupDetail/FisDetail")]
        public async Task<IActionResult> CariReportSubGroupDetailFromFisNo(string fisNo, string subeKod)
        {
            var result = await _cariReportManager.GetCariReportSubGroupDetailFromFisNo(new CariReportFilterModel { FisNo=fisNo, SubeKod=subeKod });

            if (result.Success)
            {
                return Ok(result.Data.ToList());
            }
            else
            {
                return NoContent();
            }

        }
    }

    public class TestModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
