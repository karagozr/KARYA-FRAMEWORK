using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.MODEL.Dtos.Hanel.Finance.Budget
{
    public class ActualCostWithMonths
    {
        public string BudgetMainGroup { get; set; } = "";
        public string BudgetSubGroup { get; set; } = "";
        public string BudgetMainCode { get; set; } = "";
        public string BudgetMainCodeDesc { get; set; } = "";
        public string BudgetSubCode { get; set; } = "";
        public string BudgetSubCodeDesc { get; set; } = "";
        public string ProjectCode { get; set; } = "";
        public string BranchCode { get; set; } = "";
        public string BranchName { get; set; } = "";
        public string CurrencyCode { get; set; }
        public double Ocak { get; set; }
        public int OcakId { get; set; }
        public double Subat { get; set; }
        public int SubatId { get; set; }
        public double Mart { get; set; }
        public int MartId { get; set; }
        public double Nisan { get; set; }
        public int NisanId { get; set; }
        public double Mayis { get; set; }
        public int MayisId { get; set; }
        public double Haziran { get; set; }
        public int HaziranId { get; set; }
        public double Temmuz { get; set; }
        public int TemmuzId { get; set; }
        public double Agustos { get; set; }
        public int AgustosId { get; set; }
        public double Eylul { get; set; }
        public int EylulId { get; set; }
        public double Ekim { get; set; }
        public int EkimId { get; set; }
        public double Kasim { get; set; }
        public int KasimId { get; set; }
        public double Aralik { get; set; }
        public int AralikId { get; set; }
    }
}
