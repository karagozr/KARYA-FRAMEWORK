using KARYA.MODEL.Enums.HanelApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KARYA.API.REST.Models.Finance
{
    public class BudgetModel
    {
        public int Id { get; set; }
        public BudgetType BudgetType { get; set; }
        public string BudgetMainGroup { get; set; }
        public string BudgetSubGroup { get; set; } 
        public string BudgetMainCode { get; set; }
        public string BudgetSubCode { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string BranchCode { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Ocak { get; set; }
        public decimal Subat { get; set; }
        public decimal Mart { get; set; }
        public decimal Nisan { get; set; }
        public decimal Mayis { get; set; }
        public decimal Haziran { get; set; }
        public decimal Temmuz { get; set; }
        public decimal Agustos { get; set; }
        public decimal Eylul { get; set; }
        public decimal Ekim { get; set; }
        public decimal Kasim { get; set; }
        public decimal Aralik { get; set; }
        public int OcakId { get; set; }
        public int SubatId { get; set; }
        public int MartId { get; set; }
        public int NisanId { get; set; }
        public int MayisId { get; set; }
        public int HaziranId { get; set; }
        public int TemmuzId { get; set; }
        public int AgustosId { get; set; }
        public int EylulId { get; set; }
        public int EkimId { get; set; }
        public int KasimId { get; set; }
        public int AralikId { get; set; }
    }
}
