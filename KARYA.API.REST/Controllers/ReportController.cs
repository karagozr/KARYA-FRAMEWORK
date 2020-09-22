using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using KARYA.API.REST.Models.Finance;
using KARYA.BUSINESS.Abstract.Hanel.Finance;
using KARYA.BUSINESS.Abstract.Hanel.PlReport;
using KARYA.MODEL.Common.HanelApp.PlReport;
using KARYA.MODEL.Dtos;
using KARYA.MODEL.Entities.Finance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KARYA.API.REST.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ReportController : Controller
    {
        IPlReportManager _plReportManager;
        IPivotReportTemplateManager _reportTemplateManager; 
        public ReportController(IPlReportManager plReportManager, IPivotReportTemplateManager reportTemplateManager)
        {
            _plReportManager = plReportManager;
            _reportTemplateManager = reportTemplateManager;
        }

        [HttpPost("getpl")]
        public async Task<IActionResult> GetPlReportValues(PlReportFilterModel plReportFilterModel)
        {
            var resultData = await _plReportManager.GetReport(plReportFilterModel);

            //return new PlReport
            //{
            //    Budget = 50000,
            //    ActualCost = 60000,
            //    Differance = 10000,
            //    Rate = 0.2,
            //    LastActualCost = 55000,
            //    LastDifferance = 5000,
            //    LastRate = 0.1
            //};

            if (resultData.Success)
            {
                return Ok(new
                {
                    success = resultData.Success,
                    message = resultData.Message,
                    resultData = resultData.Data
                });
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
                //return Ok(new
                //{
                //    success = resultData.Success,
                //    message = resultData.Message,
                //    resultData = resultData.Data
                //});
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("getpldetail")]
        public async Task<IActionResult> GetPlReportDetailValues(PlReportFilterModel plReportFilterModel)
        {
            var resultData = await _plReportManager.GetPeportValuesDetails(plReportFilterModel);

            if (resultData.Success)
            {
                return Ok(resultData.Data.ToList());
                //return Ok(new
                //{
                //    success = resultData.Success,
                //    message = resultData.Message,
                //    resultData = resultData.Data
                //});
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
                //return Ok(new
                //{
                //    success = filterData.Success,
                //    message = filterData.Message,
                //    resultData = filterData.Data.ToList()
                //});
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
                return Ok(resultData);
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

        [HttpPost("testpostap")]
        public async Task<IActionResult> TestPost(TestModel testModel)
        {
            if (testModel.Id == 1)
            {
                return Ok(new
                {
                    success = true,
                    message = "Başarılı",
                    resultData = "Data"
                });
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
