using Report.Business.Manager.Implement;
using Report.Business.Manager.Interface;
using Report.Business.Settings;
using Report.Repository.Repository.Interface;
using Report.Repository.Repository.Implement;

namespace Report.Extensions
{
    public static class StartupExtension
    {
        public static IConfiguration Configuration { get; set; }
        public static void AddManagers(this IServiceCollection services)
        {
            services.AddScoped<IReportManager, ReportManager>();
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IReportRepository, ReportRepository>();
        }
    }
}
