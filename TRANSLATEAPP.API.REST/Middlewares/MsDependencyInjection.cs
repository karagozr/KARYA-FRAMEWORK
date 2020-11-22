using KARYA.BUSINESS.Abstract.TranslateApp;
using KARYA.BUSINESS.Concrete.TranslateApp;
using Microsoft.Extensions.DependencyInjection;

namespace TRANSLATEAPP.API.REST.Middlewares
{
    public static class MsDependencyInjection
    {
        public static void AddMsDependencies(this IServiceCollection services)
        {
      
            services.AddScoped<IInnovaUserManager, InnovaUserManager>();

        }
    }
}
