using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Report.Business.Queue.Core;
using Report.Repository.Entities;
using Report.Repository.Models;
using Report.Repository.Repository.Interface;
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
			using (var scope = _serviceProvider.CreateScope())
			{
				IReportRepository _reportRepository = scope.ServiceProvider.GetService<IReportRepository>();
				IContactInfoRepository _contactInfoRepository = scope.ServiceProvider.GetService<IContactInfoRepository>();
				IReportContentRepository _reportContentRepository = scope.ServiceProvider.GetService<IReportContentRepository>();

				ReportContent reportContent = new ReportContent();
				reportContent.Location = reportLookup.Location;
				reportContent.PersonCount = await _contactInfoRepository.PersonCountWithLocation(reportLookup.Location);
				reportContent.PhoneCount = await _contactInfoRepository.PhoneCountWithLocation(reportLookup.Location);

				await _reportContentRepository.AddReportContent(reportContent);


				await _reportRepository.UpdateReportLookup(reportLookup);
			}


		}
	}
}
