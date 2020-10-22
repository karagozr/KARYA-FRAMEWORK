using KARYA.DATAACCESS.Helpers;
using KARYA.MODEL.Entities;
using KARYA.MODEL.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.DATAACCESS.Concrete.EntityFramework.Context
{
    public class HanelContext : DbContext
    {
        public string _connectionString;
        public HanelContext()
        {
            _connectionString = DbConnectionHelper.GetConnectionString("HANELConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Budget> Budget { get; set; }

        public DbSet<BudgetDetail> BudgetDetail { get; set; }

        public DbSet<BudgetSubDetail> BudgetSubDetail { get; set; }

        public DbSet<BudgetExchangeRate> BudgetExchangeRate { get; set; }

        public DbSet<PivotReportTemplate> PivotReportTemplate { get; set; }

    }
}
