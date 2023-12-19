using Contact.Business.Manager.Implement;
using Contact.Business.Manager.Interface;
using Contact.Business.Queue.Core;
using Contact.Extensions;
using Contact.Repository.Models;
using Contact.Repository.Repository.Implement;
using Contact.Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Contact
{
    public class Startup
	{
		public const string TestEnv = "X_UNIT_TEST";
		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
			StartupExtension.Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddEndpointsApiExplorer();
			services.Configure<RabbitMqConfiguration>(a => Configuration.GetSection(nameof(RabbitMqConfiguration)).Bind(a));
			services.AddSingleton<IRabbitMqService, RabbitMqService>();

			services.AddDbContext<ApplicationContext>(
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
}
