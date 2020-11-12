using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KARYA.API.REST.Models.Finance;
using KARYA.BUSINESS.Abstract.Hanel.Finance;
using KARYA.BUSINESS.Abstract.Hanel.PlReport;
using KARYA.MODEL.Dtos.Hanel.Finance.Budget;
using KARYA.MODEL.Entities.Finance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;

namespace KARYA.API.REST.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BudgetController : Controller
    {
        IActualCostManager _actualCostManager;
        IBudgetManager _budgetManager;
        IBudgetDetailManager _budgetDetailManager;
        IBudgetActualCostManager _budgetActualCostManager;
        IBudgetCodeNameManager _budgetCodeNameManager;
        IBudgetSubDetailManager _budgetSubDetailManager;
        public BudgetController(IActualCostManager actualCostManager, IBudgetManager budgetManager, 
            IBudgetDetailManager budgetDetailManager, IBudgetCodeNameManager budgetCodeNameManager,
            IBudgetActualCostManager budgetActualCostManager, IBudgetSubDetailManager budgetSubDetailManager)
        {
            _budgetManager = budgetManager;
            _budgetDetailManager = budgetDetailManager;
            _actualCostManager = actualCostManager;
            _budgetActualCostManager = budgetActualCostManager;
            _budgetCodeNameManager = budgetCodeNameManager;
            _budgetSubDetailManager = budgetSubDetailManager;
        }

        [HttpGet("GetActualForBudget")]
        public async Task<IActionResult> GetActualCostForProject(string projectCode, short year, string currency)
        {
            var resultData = await _actualCostManager.GetActualCostWithMonths(projectCode, year, currency);

            if (resultData.Success)
            {
                return Ok(resultData.Data);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("GetProjectBudgetList")]
        public async Task<IActionResult> GetProjectBudgetListWithStatus(short budgetYear)
        {
            var resultDataProjectBudget = await _budgetActualCostManager.GetProjectsBudgetListWithStatus(budgetYear);
            if (!resultDataProjectBudget.Success) return BadRequest(resultDataProjectBudget.Message);

            return Ok(resultDataProjectBudget.Data);
        }

        [HttpGet("GetBudgetsWithActual")]
        public async Task<IActionResult> GetBudgetwithMonths(string projectCode, short budgetYear, short actualYear, string currencyCode)
        {
            //var resultDataActual = await _actualCostManager.GetActualCostWithMonths(projectCode, actualYear, currency);
            //if (!resultDataActual.Success) return BadRequest(resultDataActual.Message);
            //var actualData = resultDataActual.Data.ToList();

            //var budgetCodesresultData = await _budgetCodeNameManager.List();
            //if (!budgetCodesresultData.Success) return BadRequest(budgetCodesresultData.Message);
            //var budgetCodes = budgetCodesresultData.Data;



            var resultDataBudget = await _budgetActualCostManager.GetActualBudgetCostWithMonths(projectCode, budgetYear, actualYear, currencyCode);
            if (!resultDataBudget.Success) return BadRequest(resultDataBudget.Message);
            var budgetData = resultDataBudget.Data;

            var resultDataBudgetSubDetail = await _budgetSubDetailManager.Select(budgetData.Select(x => x.Id));
            if (!resultDataBudgetSubDetail.Success) return BadRequest(resultDataBudget.Message);
            var budgetDataSubDetail = resultDataBudgetSubDetail.Data;

            return Ok(new { budgetData, budgetDataSubDetail });
        }

        [HttpPost("SaveBudgetList")]
        public async Task<IActionResult> SaveBudgetForProject(IEnumerable<BudgetAndActualWithMonthsDto> saveBudgetModel)
        {

            //var projectCode = saveBudgetModel.ProjectCode;
            //var bugdetList = saveBudgetModel.BugdetList;
            //short year = saveBudgetModel.BuggetYear;

            //foreach (var item in bugdetList)
            //{
            //    var budget = new Budget
            //    {
            //        Id=item.Id>0?item.Id:-1,
            //        BudgetType=item.BudgetType,
            //        ProjectCode = projectCode,
            //        BranchCode = item.BranchCode,
            //        BudgetMainCode = item.BudgetMainCode,
            //        BudgetSubCode = item.BudgetSubCode,
            //        Description1 = item.Description1,
            //        Description2 = item.Description2,
            //        Description3 = item.Description3,
            //        BudgetYear = year,
            //        Enable = true,
            //        BudgetTaxMultiplier = 1
            //    };

            //    var res =  budget.Id<=0? await _budgetManager.Add(budget): await _budgetManager.Update(budget);

            //    if (!res.Success) return BadRequest();

            //    int id = _budgetManager.ScopeIdentity();

            //    var budgetDetailList = new List<BudgetDetail>()
            //    {
            //        new BudgetDetail
            //        {
            //            Id=item.OcakId>0?item.OcakId:-1,
            //            PeriodDate=DateTime.Now,
            //            BudgetId=id,
            //            Enable=true,
            //            BudgetYear=year,
            //            BudgetMonth=1,
            //            Amount=item.Ocak,
            //            CurrencyCode=item.CurrencyCode
            //        },
            //        new BudgetDetail
            //        {
            //            Id=item.SubatId>0?item.SubatId:-1,
            //            PeriodDate=DateTime.Now,
            //            BudgetId=id,
            //            Enable=true,
            //            BudgetYear=year,
            //            BudgetMonth=2,
            //            Amount=item.Subat,
            //            CurrencyCode=item.CurrencyCode
            //        },
            //        new BudgetDetail
            //        {
            //            Id=item.MartId>0?item.MartId:-1,
            //            PeriodDate=DateTime.Now,
            //            BudgetId=id,
            //            Enable=true,
            //            BudgetYear=year,
            //            BudgetMonth=3,
            //            Amount=item.Mart,
            //            CurrencyCode=item.CurrencyCode
            //        },
            //        new BudgetDetail
            //        {
            //            Id=item.NisanId>0?item.NisanId:-1,
            //            PeriodDate=DateTime.Now,
            //            BudgetId=id,
            //            Enable=true,
            //            BudgetYear=year,
            //            BudgetMonth=4,
            //            Amount=item.Nisan,
            //            CurrencyCode=item.CurrencyCode
            //        },
            //        new BudgetDetail
            //        {
            //            Id=item.MayisId>0?item.MayisId:-1,
            //            PeriodDate=DateTime.Now,
            //            BudgetId=id,
            //            Enable=true,
            //            BudgetYear=year,
            //            BudgetMonth=5,
            //            Amount=item.Mayis,
            //            CurrencyCode=item.CurrencyCode
            //        },
            //        new BudgetDetail
            //        {
            //            Id=item.HaziranId>0?item.HaziranId:-1,
            //            PeriodDate=DateTime.Now,
            //            BudgetId=id,
            //            Enable=true,
            //            BudgetYear=year,
            //            BudgetMonth=6,
            //            Amount=item.Haziran,
            //            CurrencyCode=item.CurrencyCode
            //        },
            //        new BudgetDetail
            //        {
            //            Id=item.TemmuzId>0?item.TemmuzId:-1,
            //            PeriodDate=DateTime.Now,
            //            BudgetId=id,
            //            Enable=true,
            //            BudgetYear=year,
            //            BudgetMonth=7,
            //            Amount=item.Temmuz,
            //            CurrencyCode=item.CurrencyCode
            //        },
            //        new BudgetDetail
            //        {
            //            Id=item.AgustosId>0?item.AgustosId:-1,
            //            PeriodDate=DateTime.Now,
            //            BudgetId=id,
            //            Enable=true,
            //            BudgetYear=year,
            //            BudgetMonth=8,
            //            Amount=item.Agustos,
            //            CurrencyCode=item.CurrencyCode
            //        },
            //        new BudgetDetail
            //        {
            //            Id=item.EylulId>0?item.EylulId:-1,
            //            PeriodDate=DateTime.Now,
            //            BudgetId=id,
            //            Enable=true,
            //            BudgetYear=year,
            //            BudgetMonth=9,
            //            Amount=item.Eylul,
            //            CurrencyCode=item.CurrencyCode
            //        },
            //        new BudgetDetail
            //        {
            //            Id=item.EkimId>0?item.EkimId:-1,
            //            PeriodDate=DateTime.Now,
            //            BudgetId=id,
            //            Enable=true,
            //            BudgetYear=year,
            //            BudgetMonth=10,
            //            Amount=item.Ekim,
            //            CurrencyCode=item.CurrencyCode
            //        },
            //        new BudgetDetail
            //        {
            //            Id=item.KasimId>0?item.KasimId:-1,
            //            PeriodDate=DateTime.Now,
            //            BudgetId=id,
            //            Enable=true,
            //            BudgetYear=year,
            //            BudgetMonth=11,
            //            Amount=item.Kasim,
            //            CurrencyCode=item.CurrencyCode
            //        },
            //        new BudgetDetail
            //        {
            //            Id=item.AralikId>0?item.AralikId:-1,
            //            PeriodDate=DateTime.Now,
            //            BudgetId=id,
            //            Enable=true,
            //            BudgetYear=year,
            //            BudgetMonth=12,
            //            Amount=item.Aralik,
            //            CurrencyCode=item.CurrencyCode
            //        }

            //    };

            //    var resDet = await _budgetDetailManager.AddList(budgetDetailList.Where(x=>x.Id<=0));
            //    resDet = await _budgetDetailManager.UpdateList(budgetDetailList.Where(x => x.Id > 0));

            //    if (!resDet.Success) return BadRequest();
            //}

            return Ok();
        }



    }
}
