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
		private readonly IReportRepository _reportRepository;
		private readonly IContactInfoRepository _contactInfoRepository;
		private readonly IReportContentRepository _reportContentRepository;


		public ReportSubscriber(IRabbitMqService rabbitMqService
			,IReportRepository reportRepository
			,IContactInfoRepository contactInfoRepository
			,IReportContentRepository reportContentRepository
			) : base(rabbitMqService)
		{
			_reportRepository = reportRepository;
			_contactInfoRepository = contactInfoRepository;
			_reportContentRepository = reportContentRepository;
		}

		public override async Task HandleMessage(ReportLookup reportLookup)
		{
			ReportContent reportContent =new ReportContent();
			reportContent.Location = reportLookup.Location;
			reportContent.PersonCount = await _contactInfoRepository.PersonCountWithLocation(reportLookup.Location);
			reportContent.PhoneCount = await _contactInfoRepository.PhoneCountWithLocation(reportLookup.Location);

			await _reportContentRepository.AddReportContent(reportContent);


			await _reportRepository.UpdateReportLookup(reportLookup);

		}
	}
}
