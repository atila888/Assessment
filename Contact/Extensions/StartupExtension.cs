using Contact.Business.Manager.Implement;
using Contact.Business.Manager.Interface;
using Contact.Business.Queue.Core;
using Contact.Repository.Repository.Implement;
using Contact.Repository.Repository.Interface;

namespace Contact.Extensions
{
    public static class StartupExtension
    {
        public static IConfiguration Configuration { get; set; }
        public static void AddManagers(this IServiceCollection services)
        {
            services.AddScoped<IContactManager, ContactManager>();
            services.AddScoped<IReportManager, ReportManager>();
            services.AddScoped<IMessageProducer, MessageProducer>();
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IContactInfoRepository, ContactInfoRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IReportContentRepository, ReportContentRepository>();
        }
    }
}
