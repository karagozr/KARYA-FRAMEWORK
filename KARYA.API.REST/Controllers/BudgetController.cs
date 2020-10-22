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
        IBudgetCodeNameManager _budgetCodeNameManager;
        public BudgetController(IActualCostManager actualCostManager, IBudgetManager budgetManager, IBudgetDetailManager budgetDetailManager, IBudgetCodeNameManager budgetCodeNameManager)
        {
            _budgetManager = budgetManager;
            _budgetDetailManager = budgetDetailManager;
            _actualCostManager = actualCostManager;
            _budgetCodeNameManager = budgetCodeNameManager;
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

        [HttpGet("GetBudgetTemplate")]
        public async Task<IActionResult> CreateNewBudgetForProject(string projectCode, string currency)
        {
            short year = DateTime.Now.Month > 6 ? (short)DateTime.Now.Year : (short)(DateTime.Now.Year - 1);
            var resultData = await _actualCostManager.GetActualCostWithMonths(projectCode, year, currency);

            foreach (var item in resultData.Data)
            {
                item.CurrencyCode = currency;
                item.Ocak = 0;
                item.Subat = 0;
                item.Mart = 0;
                item.Nisan = 0;
                item.Mayis = 0;
                item.Haziran = 0;
                item.Temmuz = 0;
                item.Agustos = 0;
                item.Eylul = 0;
                item.Ekim = 0;
                item.Kasim = 0;
                item.Aralik = 0;

                item.OcakId     = -1;
                item.SubatId    = -1;
                item.MartId     = -1;
                item.NisanId    = -1;
                item.MayisId    = -1;
                item.HaziranId  = -1;
                item.TemmuzId   = -1;
                item.AgustosId  = -1;
                item.EylulId    = -1;
                item.EkimId     = -1;
                item.KasimId    = -1;
                item.AralikId   = -1;

            }

            if (resultData.Success)
            {
                return Ok(resultData.Data);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("GetBudgetList")]
        public async Task<IActionResult> GetBudgetwithMonths(string projectCode, short year)
        {
            var budgetCodesresultData = await _budgetCodeNameManager.List();
            var budgetCodes = budgetCodesresultData.Data;
            var resultData = await _budgetDetailManager.ListOfBudgetWithMonths(projectCode, year);
            var data = resultData.Data.Join(budgetCodes,x=>x.BudgetSubCode,y=>y.SubCode, 
                (x, y) => new {
                    Id = x.Id,
                    BudgetYear = x.BudgetYear,
                    BudgetMainCode = x.BudgetMainCode,
                    BudgetMainCodeDesc = y.MainCodeDesc,
                    BudgetSubCode = x.BudgetSubCode,
                    BudgetSubCodeDesc = y.SubCodeDesc,
                    Description1 = x.Description1,
                    Description2 = x.Description2,
                    Description3 = x.Description3,
                    Ocak = x.Ocak,
                    Subat = x.Subat,
                    Mart = x.Mart,
                    Nisan = x.Nisan,
                    Mayis = x.Mayis,
                    Haziran = x.Haziran,
                    Temmuz = x.Temmuz,
                    Agustos = x.Agustos,
                    Eylul = x.Eylul,
                    Ekim = x.Ekim,
                    Kasim = x.Kasim,
                    Aralik = x.Aralik,

                    OcakId = x.OcakId,
                    SubatId = x.SubatId,
                    MartId = x.MartId,
                    NisanId = x.NisanId,
                    MayisId = x.MayisId,
                    HaziranId = x.HaziranId,
                    TemmuzId = x.TemmuzId,
                    AgustosId = x.AgustosId,
                    EylulId = x.EylulId,
                    EkimId = x.EkimId,
                    KasimId = x.KasimId,
                    AralikId = x.AralikId

                });
        
            return Ok(data);
        }

        [HttpPost("SaveBudgetList")]
        public async Task<IActionResult> SaveBudgetForProject(SaveBudgetModel saveBudgetModel)
        {
            var projectCode = saveBudgetModel.ProjectCode;
            var bugdetList = saveBudgetModel.BugdetList;
            short year = saveBudgetModel.BuggetYear;

            foreach (var item in bugdetList)
            {
                var budget = new Budget
                {
                    Id=item.Id>0?item.Id:-1,
                    BudgetType=item.BudgetType,
                    ProjectCode = projectCode,
                    BranchCode = item.BranchCode,
                    BudgetMainCode = item.BudgetMainCode,
                    BudgetSubCode = item.BudgetSubCode,
                    Description1 = item.Description1,
                    Description2 = item.Description2,
                    Description3 = item.Description3,
                    BudgetYear = year,
                    Enable = true,
                    BudgetTaxMultiplier = 1
                };

                var res =  budget.Id<=0? await _budgetManager.Add(budget): await _budgetManager.Update(budget);

                if (!res.Success) return BadRequest();

                int id = _budgetManager.ScopeIdentity();

                var budgetDetailList = new List<BudgetDetail>()
                {
                    new BudgetDetail
                    {
                        Id=item.OcakId>0?item.OcakId:-1,
                        PeriodDate=DateTime.Now,
                        BudgetId=id,
                        Enable=true,
                        BudgetYear=year,
                        BudgetMonth=1,
                        Amount=item.Ocak,
                        CurrencyCode=item.CurrencyCode
                    },
                    new BudgetDetail
                    {
                        Id=item.SubatId>0?item.SubatId:-1,
                        PeriodDate=DateTime.Now,
                        BudgetId=id,
                        Enable=true,
                        BudgetYear=year,
                        BudgetMonth=2,
                        Amount=item.Subat,
                        CurrencyCode=item.CurrencyCode
                    },
                    new BudgetDetail
                    {
                        Id=item.MartId>0?item.MartId:-1,
                        PeriodDate=DateTime.Now,
                        BudgetId=id,
                        Enable=true,
                        BudgetYear=year,
                        BudgetMonth=3,
                        Amount=item.Mart,
                        CurrencyCode=item.CurrencyCode
                    },
                    new BudgetDetail
                    {
                        Id=item.NisanId>0?item.NisanId:-1,
                        PeriodDate=DateTime.Now,
                        BudgetId=id,
                        Enable=true,
                        BudgetYear=year,
                        BudgetMonth=4,
                        Amount=item.Nisan,
                        CurrencyCode=item.CurrencyCode
                    },
                    new BudgetDetail
                    {
                        Id=item.MayisId>0?item.MayisId:-1,
                        PeriodDate=DateTime.Now,
                        BudgetId=id,
                        Enable=true,
                        BudgetYear=year,
                        BudgetMonth=5,
                        Amount=item.Mayis,
                        CurrencyCode=item.CurrencyCode
                    },
                    new BudgetDetail
                    {
                        Id=item.HaziranId>0?item.HaziranId:-1,
                        PeriodDate=DateTime.Now,
                        BudgetId=id,
                        Enable=true,
                        BudgetYear=year,
                        BudgetMonth=6,
                        Amount=item.Haziran,
                        CurrencyCode=item.CurrencyCode
                    },
                    new BudgetDetail
                    {
                        Id=item.TemmuzId>0?item.TemmuzId:-1,
                        PeriodDate=DateTime.Now,
                        BudgetId=id,
                        Enable=true,
                        BudgetYear=year,
                        BudgetMonth=7,
                        Amount=item.Temmuz,
                        CurrencyCode=item.CurrencyCode
                    },
                    new BudgetDetail
                    {
                        Id=item.AgustosId>0?item.AgustosId:-1,
                        PeriodDate=DateTime.Now,
                        BudgetId=id,
                        Enable=true,
                        BudgetYear=year,
                        BudgetMonth=8,
                        Amount=item.Agustos,
                        CurrencyCode=item.CurrencyCode
                    },
                    new BudgetDetail
                    {
                        Id=item.EylulId>0?item.EylulId:-1,
                        PeriodDate=DateTime.Now,
                        BudgetId=id,
                        Enable=true,
                        BudgetYear=year,
                        BudgetMonth=9,
                        Amount=item.Eylul,
                        CurrencyCode=item.CurrencyCode
                    },
                    new BudgetDetail
                    {
                        Id=item.EkimId>0?item.EkimId:-1,
                        PeriodDate=DateTime.Now,
                        BudgetId=id,
                        Enable=true,
                        BudgetYear=year,
                        BudgetMonth=10,
                        Amount=item.Ekim,
                        CurrencyCode=item.CurrencyCode
                    },
                    new BudgetDetail
                    {
                        Id=item.KasimId>0?item.KasimId:-1,
                        PeriodDate=DateTime.Now,
                        BudgetId=id,
                        Enable=true,
                        BudgetYear=year,
                        BudgetMonth=11,
                        Amount=item.Kasim,
                        CurrencyCode=item.CurrencyCode
                    },
                    new BudgetDetail
                    {
                        Id=item.AralikId>0?item.AralikId:-1,
                        PeriodDate=DateTime.Now,
                        BudgetId=id,
                        Enable=true,
                        BudgetYear=year,
                        BudgetMonth=12,
                        Amount=item.Aralik,
                        CurrencyCode=item.CurrencyCode
                    }

                };

                var resDet = await _budgetDetailManager.AddList(budgetDetailList.Where(x=>x.Id<=0));
                resDet = await _budgetDetailManager.UpdateList(budgetDetailList.Where(x => x.Id > 0));

                if (!resDet.Success) return BadRequest();
            }

            return Ok();
        }



    }
}
