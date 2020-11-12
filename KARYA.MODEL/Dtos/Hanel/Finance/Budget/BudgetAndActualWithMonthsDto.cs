using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.MODEL.Dtos.Hanel.Finance.Budget
{
    public class BudgetAndActualWithMonthsDto : Entities.Finance.Budget
    {
        public string ForeingId { get; set; }
        public string BranchName { get; set; }
        public string BudgetMainGroup { get; set; }
        public string BudgetSubGroup { get; set; }
        public string BudgetMainCodeDesc { get; set; }
        public string BudgetSubCodeDesc { get; set; }
        public string BudgetCurrencyCode { get; set; }
        public string ActualCurrencyCode { get; set; }
        public decimal BudgetOcak { get; set; }
        public decimal BudgetSubat { get; set; }
        public decimal BudgetMart { get; set; }
        public decimal BudgetNisan { get; set; }
        public decimal BudgetMayis { get; set; }
        public decimal BudgetHaziran { get; set; }
        public decimal BudgetTemmuz { get; set; }
        public decimal BudgetAgustos { get; set; }
        public decimal BudgetEylul { get; set; }
        public decimal BudgetEkim { get; set; }
        public decimal BudgetKasim { get; set; }
        public decimal BudgetAralik { get; set; }
        public decimal ActualOcak { get; set; }
        public decimal ActualSubat { get; set; }
        public decimal ActualMart { get; set; }
        public decimal ActualNisan { get; set; }
        public decimal ActualMayis { get; set; }
        public decimal ActualHaziran { get; set; }
        public decimal ActualTemmuz { get; set; }
        public decimal ActualAgustos { get; set; }
        public decimal ActualEylul { get; set; }
        public decimal ActualEkim { get; set; }
        public decimal ActualKasim { get; set; }
        public decimal ActualAralik { get; set; }
        public int BudgetOcakId { get; set; }
        public int BudgetSubatId { get; set; }
        public int BudgetMartId { get; set; }
        public int BudgetNisanId { get; set; }
        public int BudgetMayisId { get; set; }
        public int BudgetHaziranId { get; set; }
        public int BudgetTemmuzId { get; set; }
        public int BudgetAgustosId { get; set; }
        public int BudgetEylulId { get; set; }
        public int BudgetEkimId { get; set; }
        public int BudgetKasimId { get; set; }
        public int BudgetAralikId { get; set; }



    }
}
