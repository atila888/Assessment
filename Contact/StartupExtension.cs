using Contact.Business.Manager.Implement;
using Contact.Business.Manager.Interface;
using Contact.Business.Queue.Core;
using Contact.Repository.Models;
using Contact.Repository.Repository.Implement;
using Contact.Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Contact
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

			services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationContext>(
				options => options.UseNpgsql(Configuration.GetConnectionString("PostgresqlConnection")));

			//services.AddCommonService();
			//services.AddDbContext();
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
			services.AddScoped<IContactManager, ContactManager>();
			services.AddScoped<IReportManager, ReportManager>();
			services.AddScoped<IMessageProducer, MessageProducer>();
		}
		public static void AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IContactInfoRepository, ContactInfoRepository>();
			services.AddScoped<IPersonRepository, PersonRepository>();
			services.AddScoped<IReportRepository, ReportRepository>();
		}
	}
}
