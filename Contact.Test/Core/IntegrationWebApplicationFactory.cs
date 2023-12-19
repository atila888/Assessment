using Contact.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Test.Core
{
	public class IntegrationWebApplicationFactory<TStartup>
	   : WebApplicationFactory<TStartup> where TStartup : class
	{
		protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			builder.UseEnvironment(Startup.TestEnv);
			builder.ConfigureAppConfiguration(con =>
			{
				StartupExtension.Configuration = con.Build();
			});
		}
	}
}
