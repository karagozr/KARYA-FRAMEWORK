using KARYA.BUSINESS.Abstract.Hanel.Finance;
using KARYA.BUSINESS.Abstract.Hanel.PlReport;
using KARYA.BUSINESS.Abstract.Karya;
using KARYA.BUSINESS.Concrete;
using KARYA.BUSINESS.Concrete.Hanel.Finance;
using KARYA.BUSINESS.Concrete.Karya;
using KARYA.DATAACCESS.Abstract.Hanel;
using KARYA.DATAACCESS.Abstract.Hanel.Finance;
using KARYA.DATAACCESS.Abstract.Karya;
using KARYA.DATAACCESS.Concrete.EntityFramework;
using KARYA.DATAACCESS.Concrete.EntityFramework.Hanel;
using KARYA.DATAACCESS.Concrete.EntityFramework.Hanel.Finance;
using Microsoft.Extensions.DependencyInjection;

namespace KARYA.API.REST.Middlewares
{
    public static class MsDependencyInjection
    {
        public static void AddMsDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserManager, UserManager>();
            services.AddSingleton<IUserDal, UserDal>();
            services.AddScoped<IPlReportManager, PlReportManager>();
            services.AddScoped<ICariReportManager, CariReportManager>();
            services.AddScoped<IActualCostManager, ActualCostManager>();

            services.AddScoped<IBudgetDal, BudgetDal>();
            services.AddScoped<IBudgetManager, BudgetManager>();
            services.AddScoped<IBudgetDetailDal, BudgetDetailDal>();
            services.AddScoped<IBudgetDetailManager, BudgetDetailManager>();

            services.AddScoped<IBudgetCodeNameManager, BudgetCodeNameManager>();

            services.AddScoped<IPivotReportTemplateDal, PivotReportTemplateDal>();
            services.AddScoped<IPivotReportTemplateManager, PivotReportTemplateManager>();

        }
    }
}
