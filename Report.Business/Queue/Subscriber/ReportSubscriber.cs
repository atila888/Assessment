using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Report.Business.Helper;
using Report.Business.Queue.Core;
using Report.Repository.Entities;
using Report.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Business.Queue.Subscriber
{
	public class ReportSubscriber : MessageConsumer<ReportLookup>
	{
		private readonly IServiceProvider _serviceProvider;

		public ReportSubscriber(IRabbitMqService rabbitMqService
			,IServiceProvider serviceProvider
			) : base(rabbitMqService)
		{
			_serviceProvider = serviceProvider;
		}

		public override async Task HandleMessage(ReportLookup reportLookup)
		{
			try
			{
				await HTTPClientWrapper<ReportLookup>.PostAsync("",reportLookup);
            }
			catch (Exception)
			{

				throw;
			}
		}
	}
}
