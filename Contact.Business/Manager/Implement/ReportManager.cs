using Contact.Business.Manager.Interface;
using Contact.Business.Queue.Core;
using Contact.Repository.Entities;
using Contact.Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.Manager.Implement
{
	public class ReportManager : IReportManager
	{
		private readonly IReportRepository _reportRepository;
        private readonly IContactInfoRepository _contactInfoRepository;
        private readonly IReportContentRepository _reportContentRepository;
        private readonly IMessageProducer _messageProducer;
		public ReportManager(
			IReportRepository reportRepository,
			IContactInfoRepository contactInfoRepository,
            IReportContentRepository reportContentRepository,
            IMessageProducer messageProducer)
		{
			_reportRepository= reportRepository;
			_contactInfoRepository= contactInfoRepository;
			_reportContentRepository= reportContentRepository;
			_messageProducer= messageProducer;
		}
		public async Task<bool> GetLocationReport(string location)
		{
			try
			{
				ReportLookup reportLookup=new ReportLookup();
				reportLookup.Location = location;
				reportLookup.RequestDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
				reportLookup.Statu = "Hazırlanıyor";

				await _reportRepository.GetLocationReport(reportLookup);

				_messageProducer.SendMessage(reportLookup);

                Console.WriteLine("Log : RabbitMQ kuyruğuna yazıldı");

                return true;
			}
			catch 
			{
				return false;
			}
		}
        public async Task<bool> ExecLocationReport(ReportLookup reportLookup)
        {
            Console.WriteLine("Log : HttpClient üzerinden istek geldi");
            try
            {
                ReportContent reportContent = new ReportContent();
                reportContent.Location = reportLookup.Location;
                reportContent.PersonCount = await _contactInfoRepository.PersonCountWithLocation(reportLookup.Location);
                reportContent.PhoneCount = await _contactInfoRepository.PhoneCountWithLocation(reportLookup.Location);

                await _reportContentRepository.AddReportContent(reportContent);

                await _reportRepository.UpdateReportLookup(reportLookup);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
