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
		private readonly IMessageProducer _messageProducer;
		public ReportManager(IReportRepository reportRepository,IMessageProducer messageProducer)
		{
			_reportRepository= reportRepository;
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

				return true;
			}
			catch 
			{
				return false;
			}
		}
	}
}
