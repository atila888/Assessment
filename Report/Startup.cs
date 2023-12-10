using Microsoft.EntityFrameworkCore;
using Report.Business.Manager.Implement;
using Report.Business.Manager.Interface;
using Report.Business.Queue.Core;
using Report.Business.Queue.Subscriber;
using Report.Repository.Models;
using Report.Repository.Repository.Implement;
using Report.Repository.Repository.Interface;

namespace Report
{
    public class Startup
	{
		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddEndpointsApiExplorer();
			services.Configure<RabbitMqConfiguration>(a => Configuration.GetSection(nameof(RabbitMqConfiguration)).Bind(a));
			services.AddSingleton<IRabbitMqService, RabbitMqService>();
			services.AddHostedService<ReportSubscriber>();

			services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationContext>(
				options => options.UseNpgsql(Configuration.GetConnectionString("PostgresqlConnection")));

			services.AddManagers();
			services.AddRepositories();


		}

		public void Configure(WebApplication app, IWebHostEnvironment env)
		{
			app.UseAuthorization();
			app.MapControllers();
		}
	}
	public static class StartupExtension
	{
		public static void AddManagers(this IServiceCollection services)
		{
			services.AddScoped<IReportManager, ReportManager>();
		}
		public static void AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IContactInfoRepository, ContactInfoRepository>();
			services.AddScoped<IReportContentRepository, ReportContentRepository>();
			services.AddScoped<IReportRepository, ReportRepository>();
		}
	}
}
