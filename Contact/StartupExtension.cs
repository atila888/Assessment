﻿using Contact.Business.Queue.Core;
using Contact.Repository.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Contact
{
	public class StartupExtension
	{
		public IConfiguration Configuration { get; }
		public StartupExtension(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();

			services.AddDbContext<ApplicationContext>(
				 options => {
					 options.UseNpgsql(Configuration.GetConnectionString("PostgresqlConnection"));
				 });
		}

		public void Configure(WebApplication app, IWebHostEnvironment env)
		{
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseAuthorization();

			app.MapControllers();
		}
		public static void AddCommonService(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<RabbitMqConfiguration>(a => configuration.GetSection(nameof(RabbitMqConfiguration)).Bind(a));
			services.AddSingleton<IRabbitMqService, RabbitMqService>();
		}
	}
}
